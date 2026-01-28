using System.Text.Json;
using Backend_PT1.Data;   
using Backend_PT1.Models; 

namespace Backend_PT1.Services; 

public interface IRickMortyService {
   Task<RmResponse?> GetCharacters(int page, string? name, string? status, string? species, string? type, string? gender);
    Task<CharacterDto?> GetDetail(int id);
}

public class RickMortyService : IRickMortyService
{
    private readonly HttpClient _http;
    private readonly AppDbContext _db;

    public RickMortyService(HttpClient http, AppDbContext db)
    {
        _http = http;
        _db = db;
        _http.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
    }

    public async Task<RmResponse?> GetCharacters(int page, string? name, string? status, string? species, string? type, string? gender)
    {
        
        _db.SearchHistory.Add(new SearchLog
        {
            EndpointCalled = "GetCharacters",
            SearchTerm = $"Page:{page}|Name:{name}|Status:{status}|Sp:{species}|Type:{type}|Gen:{gender}",
            DateAccessed = DateTime.Now
        });
        await _db.SaveChangesAsync();

        
        var query = $"character/?page={page}";
        if (!string.IsNullOrWhiteSpace(name)) query += $"&name={name}";
        if (!string.IsNullOrWhiteSpace(status)) query += $"&status={status}";
        if (!string.IsNullOrWhiteSpace(species)) query += $"&species={species}";
        if (!string.IsNullOrWhiteSpace(type)) query += $"&type={type}";
        if (!string.IsNullOrWhiteSpace(gender)) query += $"&gender={gender}";

        var response = await _http.GetAsync(query);
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<RmResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<CharacterDto?> GetDetail(int id)
    {
        //  Traer Personaje
        var response = await _http.GetAsync($"character/{id}");
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        var character = JsonSerializer.Deserialize<CharacterDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (character != null && character.EpisodeUrls.Any())
        {
            //  Extraer IDs de los episodios
            var episodeIds = character.EpisodeUrls
                .Select(u => u.Split('/').Last())
                .ToList();

            if (episodeIds.Any())
            {
                // Llamada Batch a la API de episodios 
                var idsString = string.Join(",", episodeIds);
                var epResponse = await _http.GetAsync($"episode/{idsString}");
                
                if (epResponse.IsSuccessStatusCode)
                {
                    var epContent = await epResponse.Content.ReadAsStringAsync();
                    
                    using (JsonDocument doc = JsonDocument.Parse(epContent))
                    {
                        if (doc.RootElement.ValueKind == JsonValueKind.Array)
                        {
                            character.EpisodeList = JsonSerializer.Deserialize<List<EpisodeDto>>(epContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
                        }
                        else
                        {
                            var singleEp = JsonSerializer.Deserialize<EpisodeDto>(epContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (singleEp != null) character.EpisodeList.Add(singleEp);
                        }
                    }
                }
            }
        }

        return character;
    }
}