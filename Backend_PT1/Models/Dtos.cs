using System.Text.Json.Serialization;

namespace Backend_PT1.Models;

public class CharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public LocationDto? Location { get; set; }
    public LocationDto? Origin { get; set; }

    // Episodios del personaje
    public List<EpisodeDto> EpisodeList { get; set; } = new();

    [JsonPropertyName("episode")]
    public List<string> EpisodeUrls { get; set; } = new();
}

public class EpisodeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Episode { get; set; } = string.Empty; // Ej: S01E05
    [JsonPropertyName("air_date")]
    public string AirDate { get; set; } = string.Empty;
}

public class LocationDto
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}

public class RmResponse
{
    public RmInfo Info { get; set; }
    public List<CharacterDto> Results { get; set; }
}

public class RmInfo
{
    public int Pages { get; set; }
    public string? Next { get; set; }
    public string? Prev { get; set; }
}

public class SearchLog
{
    public int Id { get; set; }
    public string EndpointCalled { get; set; } = string.Empty;
    public string? SearchTerm { get; set; }
    public DateTime DateAccessed { get; set; }
}