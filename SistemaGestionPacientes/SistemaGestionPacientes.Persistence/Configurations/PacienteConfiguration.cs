using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionPacientes.Domain.Entities;

namespace SistemaGestionPacientes.Persistence.Configurations;

public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nombres)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Apellidos)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Documento)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.Telefono)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.Correo)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Direccion)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Sexo)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasIndex(p => p.Documento)
            .IsUnique();

        builder.HasIndex(p => p.Correo)
            .IsUnique();
    }
}