
using Microsoft.AspNetCore.Mvc;
using SistemaGestionPacientes.Application.Interfaces.Services;
using SistemaGestionPacientes.Application.DTOs.Especialidades;

namespace SistemaGestionPacientes.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EspecialidadesController : ControllerBase
{
    private readonly IEspecialidadService _service;

    public EspecialidadesController(IEspecialidadService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var especialidades = await _service.ObtenerTodosAsync();
        return Ok(especialidades);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var especialidad = await _service.ObtenerPorIdAsync(id);

        if (especialidad == null)
            return NotFound();

        return Ok(especialidad);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(EspecialidadDTO dto)
    {
        try
        {
            var creada = await _service.CrearAsync(dto);
            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = creada.Id },
                creada
            );
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, EspecialidadDTO dto)
    {
        try
        {
            var actualizada = await _service.ActualizarAsync(id, dto);

            if (actualizada == null)
                return NotFound();

            return Ok(actualizada);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _service.EliminarAsync(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}
