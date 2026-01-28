using Microsoft.AspNetCore.Mvc;
using Backend_PT1.Services;
using Backend_PT1.Models;

namespace Backend_PT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IRickMortyService _service;

    public CharactersController(IRickMortyService service)
    {
        _service = service;
    }

    // GET: api/characters?page=1&name=rick&status=alive
    [HttpGet]
     public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] string? name = null,
        [FromQuery] string? status = null,
        [FromQuery] string? species = null,
        [FromQuery] string? type = null,   // Nuevo
        [FromQuery] string? gender = null) // Nuevo
    {
        try
        {
             var result = await _service.GetCharacters(page, name, status, species, type, gender);
            
            // Si la API externa no devuelve nada o hay error
            if (result == null || result.Results == null || !result.Results.Any()) 
                return NotFound("No characters found with the provided filters.");

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    // GET: api/characters/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        try 
        {
            var character = await _service.GetDetail(id);
            if (character == null) return NotFound($"Character with ID {id} not found.");
            
            return Ok(character);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}