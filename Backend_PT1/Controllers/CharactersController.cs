using Microsoft.AspNetCore.Mvc;
using Backend_PT1.Services;
using Backend_PT1.Models;

namespace Backend_PT1.Controllers;

// Controlador principal: Actúa como intermediario entre el Frontend y la API de Rick & Morty
[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IRickMortyService _service;

    // Usamos inyección de dependencias para separar la lógica del controlador
    public CharactersController(IRickMortyService service)
    {
        _service = service;
    }

    // Endpoint para obtener el listado, soportando filtros y paginación
    [HttpGet]
     public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] string? name = null,
        [FromQuery] string? status = null,
        [FromQuery] string? species = null,
        [FromQuery] string? type = null,   
        [FromQuery] string? gender = null) 
    {
        try
        {
            // Consultamos el servicio con los parámetros recibidos
             var result = await _service.GetCharacters(page, name, status, species, type, gender);
            
            // Validamos si la respuesta está vacía para avisar al frontend (404)
            if (result == null || result.Results == null || !result.Results.Any()) 
                return NotFound("No se encontraron personajes con esos filtros.");

            return Ok(result);
        }
        catch (Exception ex)
        {
            // Manejamos cualquier error inesperado para que la app no se rompa (500)
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    // Endpoint para obtener el detalle de un solo personaje por ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        try 
        {
            var character = await _service.GetDetail(id);

            // Si el personaje no existe, devolvemos un error controlado
            if (character == null) return NotFound($"El personaje con ID {id} no fue encontrado.");
            
            return Ok(character);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}