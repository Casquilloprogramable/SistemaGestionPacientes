using Microsoft.AspNetCore.Mvc;
using SistemaGestionPacientes.Application.DTOs.Pacientes;
using SistemaGestionPacientes.Application.Interfaces.Services;

namespace SistemaGestionPacientes.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PacientesController : ControllerBase
{
    private readonly IPacienteService _pacienteService;

    public PacientesController(IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PacienteDTO>>> ObtenerTodos(
        CancellationToken cancellationToken)
    {
        var pacientes = await _pacienteService.ObtenerTodosAsync(
            cancellationToken);

        return Ok(pacientes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PacienteDTO>> ObtenerPorId(
        int id,
        CancellationToken cancellationToken)
    {
        var paciente = await _pacienteService.ObtenerPorIdAsync(
            id, cancellationToken);

        if (paciente == null)
            return NotFound();

        return Ok(paciente);
    }

    [HttpPost]
    public async Task<ActionResult<PacienteDTO>> Crear(
        CrearPacienteDTO dto,
        CancellationToken cancellationToken)
    {
        try
        {
            var paciente = await _pacienteService.CrearAsync(
                dto, cancellationToken);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = paciente.Id },
                paciente);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<PacienteDTO>> Actualizar(
        int id,
        ActualizarPacienteDTO dto,
        CancellationToken cancellationToken)
    {
        try
        {
            var paciente = await _pacienteService.ActualizarAsync(
                id, dto, cancellationToken);

            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar(
        int id,
        CancellationToken cancellationToken)
    {
        var eliminado = await _pacienteService.EliminarAsync(
            id, cancellationToken);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}