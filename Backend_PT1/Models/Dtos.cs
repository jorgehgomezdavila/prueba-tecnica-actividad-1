using System.Text.Json.Serialization;

namespace Backend_PT1.Models;

// Define la estructura de datos del personaje para el Frontend
public class CharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    
    // origen y ubicación del personaje
    public LocationDto? Location { get; set; }
    public LocationDto? Origin { get; set; }

    // Lista con los detalles completos de los episodios
    public List<EpisodeDto> EpisodeList { get; set; } = new();

    // Usamos JsonPropertyName para mapear el nombre exacto de la API externa
    [JsonPropertyName("episode")]
    public List<string> EpisodeUrls { get; set; } = new();
}

// Modelo para mostrar la información de cada episodio
public class EpisodeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Episode { get; set; } = string.Empty; 
    
    // Mapeamos "air_date" (formato JSON) a AirDate (formato C#)
    [JsonPropertyName("air_date")]
    public string AirDate { get; set; } = string.Empty;
}

// Modelo simple para Origen y Ubicación
public class LocationDto
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}

// Clase para recibir la respuesta paginada de la API externa
public class RmResponse
{
    public RmInfo Info { get; set; } // Información de paginación
    public List<CharacterDto> Results { get; set; } // Lista de personajes
}

// Metadatos de paginación que devuelve la API externa
public class RmInfo
{
    public int Pages { get; set; } 
    public string? Next { get; set; } 
    public string? Prev { get; set; } 
}

// Guarda el historial de búsquedas 
public class SearchLog
{
    public int Id { get; set; }
    public string EndpointCalled { get; set; } = string.Empty;
    public string? SearchTerm { get; set; }
    public DateTime DateAccessed { get; set; }
}