using Microsoft.EntityFrameworkCore;
using SistemaGestionPacientes.Domain.Entities;

namespace SistemaGestionPacientes.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Especialidad> Especialidades => Set<Especialidad>();
    public DbSet<Cita> Citas => Set<Cita>();
    public DbSet<Consulta> Consultas => Set<Consulta>();
    public DbSet<Diagnostico> Diagnosticos => Set<Diagnostico>();
    public DbSet<Tratamiento> Tratamientos => Set<Tratamiento>();
    public DbSet<Medicamento> Medicamentos => Set<Medicamento>();
    public DbSet<Receta> Recetas => Set<Receta>();
    public DbSet<DetalleReceta> DetallesReceta => Set<DetalleReceta>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Rol> Roles => Set<Rol>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);

        // Relación Paciente - Citas
        modelBuilder.Entity<Cita>()
            .HasOne(c => c.Paciente)
            .WithMany(p => p.Citas)
            .HasForeignKey(c => c.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Médico - Citas
        modelBuilder.Entity<Cita>()
            .HasOne(c => c.Medico)
            .WithMany(m => m.Citas)
            .HasForeignKey(c => c.MedicoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Paciente - Consultas
        modelBuilder.Entity<Consulta>()
            .HasOne(c => c.Paciente)
            .WithMany(p => p.Consultas)
            .HasForeignKey(c => c.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Médico - Consultas
        modelBuilder.Entity<Consulta>()
            .HasOne(c => c.Medico)
            .WithMany(m => m.Consultas)
            .HasForeignKey(c => c.MedicoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Cita - Consulta (1:1)
        modelBuilder.Entity<Consulta>()
            .HasOne(c => c.Cita)
            .WithOne(c => c.Consulta)
            .HasForeignKey<Consulta>(c => c.CitaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Especialidad - Médico
        modelBuilder.Entity<Medico>()
            .HasOne(m => m.Especialidad)
            .WithMany(e => e.Medicos)
            .HasForeignKey(m => m.EspecialidadId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Consulta - Diagnósticos
        modelBuilder.Entity<Diagnostico>()
            .HasOne(d => d.Consulta)
            .WithMany(c => c.Diagnosticos)
            .HasForeignKey(d => d.ConsultaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación Consulta - Tratamientos
        modelBuilder.Entity<Tratamiento>()
            .HasOne(t => t.Consulta)
            .WithMany(c => c.Tratamientos)
            .HasForeignKey(t => t.ConsultaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación Consulta - Recetas
        modelBuilder.Entity<Receta>()
            .HasOne(r => r.Consulta)
            .WithMany(c => c.Recetas)
            .HasForeignKey(r => r.ConsultaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación Receta - Detalles
        modelBuilder.Entity<DetalleReceta>()
            .HasOne(d => d.Receta)
            .WithMany(r => r.Detalles)
            .HasForeignKey(d => d.RecetaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación Medicamento - Detalles
        modelBuilder.Entity<DetalleReceta>()
            .HasOne(d => d.Medicamento)
            .WithMany(m => m.DetallesReceta)
            .HasForeignKey(d => d.MedicamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Rol - Usuarios
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Rol)
            .WithMany(r => r.Usuarios)
            .HasForeignKey(u => u.RolId)
            .OnDelete(DeleteBehavior.Restrict);

        // Restricciones de unicidad
        modelBuilder.Entity<Paciente>()
            .HasIndex(p => p.Documento)
            .IsUnique();

        modelBuilder.Entity<Paciente>()
            .HasIndex(p => p.Correo)
            .IsUnique();

        modelBuilder.Entity<Medico>()
            .HasIndex(m => m.NumeroColegiado)
            .IsUnique();

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.NombreUsuario)
            .IsUnique();

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Correo)
            .IsUnique();

        modelBuilder.Entity<Especialidad>()
            .HasIndex(e => e.Nombre)
            .IsUnique();

        modelBuilder.Entity<Rol>()
            .HasIndex(r => r.Nombre)
            .IsUnique();

        modelBuilder.Entity<Consulta>()
            .HasIndex(c => c.CitaId)
            .IsUnique();

        // Precisión de datos
        modelBuilder.Entity<Paciente>()
            .Property(p => p.Correo)
            .HasMaxLength(150);

        modelBuilder.Entity<Paciente>()
            .Property(p => p.Documento)
            .HasMaxLength(20);
    }
}