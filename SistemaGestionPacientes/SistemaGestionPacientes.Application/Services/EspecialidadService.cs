using SistemaGestionPacientes.Application.DTOs.Especialidades;
using SistemaGestionPacientes.Application.Interfaces;
using SistemaGestionPacientes.Application.Interfaces.Services;
using SistemaGestionPacientes.Domain.Entities;

namespace SistemaGestionPacientes.Application.Services;

public class EspecialidadService : IEspecialidadService
{
    private readonly IUnitOfWork _unitOfWork;

    public EspecialidadService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EspecialidadDTO>> ObtenerTodosAsync()
    {
        var lista = await _unitOfWork.Especialidades.GetAllAsync();

        return lista.Select(Mapear);
    }

    public async Task<EspecialidadDTO?> ObtenerPorIdAsync(int id)
    {
        var especialidad = await _unitOfWork.Especialidades.GetByIdAsync(id);

        return especialidad == null ? null : Mapear(especialidad);
    }

    public async Task<EspecialidadDTO> CrearAsync(EspecialidadDTO dto)
    {
        var nombre = dto.Nombre.Trim();

        var existentes = await _unitOfWork.Especialidades.GetAllAsync();

        if (existentes.Any(e =>
            e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException(
                "La especialidad ya existe.");
        }

        var especialidad = new Especialidad
        {
            Nombre = nombre,
            Descripcion = dto.Descripcion.Trim()
        };

        await _unitOfWork.Especialidades.AddAsync(especialidad);
        await _unitOfWork.SaveChangesAsync();

        return Mapear(especialidad);
    }

    public async Task<EspecialidadDTO?> ActualizarAsync(
        int id, EspecialidadDTO dto)
    {
        var especialidad =
            await _unitOfWork.Especialidades.GetByIdAsync(id);

        if (especialidad == null)
            return null;

        var nombre = dto.Nombre.Trim();

        var existentes = await _unitOfWork.Especialidades.GetAllAsync();

        if (existentes.Any(e =>
            e.Id != id &&
            e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException(
                "Ya existe otra especialidad con ese nombre.");
        }

        especialidad.Nombre = nombre;
        especialidad.Descripcion = dto.Descripcion.Trim();

        _unitOfWork.Especialidades.Update(especialidad);
        await _unitOfWork.SaveChangesAsync();

        return Mapear(especialidad);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var especialidad =
            await _unitOfWork.Especialidades.GetByIdAsync(id);

        if (especialidad == null)
            return false;

        _unitOfWork.Especialidades.Delete(especialidad);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    private static EspecialidadDTO Mapear(Especialidad especialidad)
    {
        return new EspecialidadDTO
        {
            Id = especialidad.Id,
            Nombre = especialidad.Nombre,
            Descripcion = especialidad.Descripcion
        };
    }
}