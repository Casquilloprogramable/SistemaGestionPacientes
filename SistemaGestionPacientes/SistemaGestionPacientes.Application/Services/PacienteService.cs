using SistemaGestionPacientes.Application.DTOs.Pacientes;
using SistemaGestionPacientes.Application.Interfaces;
using SistemaGestionPacientes.Application.Interfaces.Services;
using SistemaGestionPacientes.Domain.Entities;

namespace SistemaGestionPacientes.Application.Services;

public class PacienteService : IPacienteService
{
    private readonly IUnitOfWork _unitOfWork;

    public PacienteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Obtener todos los pacientes
    public async Task<IEnumerable<PacienteDTO>> ObtenerTodosAsync(
        CancellationToken cancellationToken = default)
    {
        var pacientes = await _unitOfWork.Pacientes.GetAllAsync(
            cancellationToken);

        return pacientes.Select(MapearDTO);
    }

    // Obtener paciente por ID
    public async Task<PacienteDTO?> ObtenerPorIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var paciente = await _unitOfWork.Pacientes.GetByIdAsync(
            id, cancellationToken);

        return paciente == null ? null : MapearDTO(paciente);
    }

    // Crear paciente
    public async Task<PacienteDTO> CrearAsync(
        CrearPacienteDTO dto,
        CancellationToken cancellationToken = default)
    {
        if (dto.FechaNacimiento.Date > DateTime.Today)
            throw new InvalidOperationException(
                "La fecha de nacimiento no puede ser futura.");

        if (await _unitOfWork.Pacientes.ExisteDocumentoAsync(
            dto.Documento.Trim(),
            cancellationToken: cancellationToken))
        {
            throw new InvalidOperationException(
                "Ya existe un paciente con ese documento.");
        }

        if (await _unitOfWork.Pacientes.ExisteCorreoAsync(
            dto.Correo.Trim(),
            cancellationToken: cancellationToken))
        {
            throw new InvalidOperationException(
                "Ya existe un paciente con ese correo.");
        }

        var paciente = new Paciente
        {
            Nombres = dto.Nombres.Trim(),
            Apellidos = dto.Apellidos.Trim(),
            Documento = dto.Documento.Trim(),
            Telefono = dto.Telefono.Trim(),
            Correo = dto.Correo.Trim().ToLowerInvariant(),
            FechaNacimiento = dto.FechaNacimiento,
            Direccion = dto.Direccion.Trim(),
            Sexo = dto.Sexo.Trim()
        };

        await _unitOfWork.Pacientes.AddAsync(
            paciente, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapearDTO(paciente);
    }

    // Actualizar paciente
    public async Task<PacienteDTO?> ActualizarAsync(
        int id,
        ActualizarPacienteDTO dto,
        CancellationToken cancellationToken = default)
    {
        var paciente = await _unitOfWork.Pacientes.GetByIdAsync(
            id, cancellationToken);

        if (paciente == null)
            return null;

        if (dto.FechaNacimiento.Date > DateTime.Today)
            throw new InvalidOperationException(
                "La fecha de nacimiento no puede ser futura.");

        if (await _unitOfWork.Pacientes.ExisteDocumentoAsync(
            dto.Documento.Trim(), id, cancellationToken))
        {
            throw new InvalidOperationException(
                "El documento pertenece a otro paciente.");
        }

        if (await _unitOfWork.Pacientes.ExisteCorreoAsync(
            dto.Correo.Trim(), id, cancellationToken))
        {
            throw new InvalidOperationException(
                "El correo pertenece a otro paciente.");
        }

        paciente.Nombres = dto.Nombres.Trim();
        paciente.Apellidos = dto.Apellidos.Trim();
        paciente.Documento = dto.Documento.Trim();
        paciente.Telefono = dto.Telefono.Trim();
        paciente.Correo = dto.Correo.Trim().ToLowerInvariant();
        paciente.FechaNacimiento = dto.FechaNacimiento;
        paciente.Direccion = dto.Direccion.Trim();
        paciente.Sexo = dto.Sexo.Trim();

        _unitOfWork.Pacientes.Update(paciente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapearDTO(paciente);
    }

    // Eliminar paciente
    public async Task<bool> EliminarAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var paciente = await _unitOfWork.Pacientes.GetByIdAsync(
            id, cancellationToken);

        if (paciente == null)
            return false;

        _unitOfWork.Pacientes.Delete(paciente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    // Conversión de entidad a DTO
    private static PacienteDTO MapearDTO(Paciente paciente)
    {
        return new PacienteDTO
        {
            Id = paciente.Id,
            Nombres = paciente.Nombres,
            Apellidos = paciente.Apellidos,
            Documento = paciente.Documento,
            Telefono = paciente.Telefono,
            Correo = paciente.Correo,
            FechaNacimiento = paciente.FechaNacimiento,
            Direccion = paciente.Direccion,
            Sexo = paciente.Sexo
        };
    }
}