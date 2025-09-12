using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Database.Context;


public partial class ModelContext : DbContext
{

    public ModelContext(DbContextOptions options)
               : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // No configurar nada aquí, la configuración de la cadena de conexión se manejará al registrar los contextos
        }
    }
    public virtual DbSet<Rol> Rols { get; set; }
    public virtual DbSet<UserRol> UserRols { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<DetalleRecetum> DetalleReceta { get; set; }

    public virtual DbSet<EfectoAdverso> EfectoAdversos { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Recetum> Receta { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("FARMACO")
                    .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("ROL", "FARMACO");

            entity.Property(e => e.IdRol)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_ROL");

            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("CREATED_AT")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");

            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<UserRol>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdRol });

            entity.ToTable("USER_ROL", "FARMACO");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_USER");

            entity.Property(e => e.IdRol)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_ROL");

            entity.Property(e => e.AssignedAt)
                .HasPrecision(6)
                .HasColumnName("ASSIGNED_AT")
                .HasDefaultValueSql("CURRENT_TIMESTAMP   -- Fecha de asignación\n");

            entity.HasOne(d => d.IdRolNavigation)
                .WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_UR_ROL");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_UR_USUARIO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("USUARIO", "FARMACO");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_USER");

            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("CREATED_AT")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");

            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");

            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasColumnName("UPDATED_AT");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<DetalleRecetum>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("DETALLE_RECETA", "FARMACO");

            entity.Property(e => e.IdDetalle)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Dosis)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOSIS");
            entity.Property(e => e.Duracion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DURACION");
            entity.Property(e => e.Frecuencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FRECUENCIA");
            entity.Property(e => e.IdMedicamento)
                .HasPrecision(10)
                .HasColumnName("ID_MEDICAMENTO");
            entity.Property(e => e.IdReceta)
                .HasPrecision(10)
                .HasColumnName("ID_RECETA");

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.DetalleReceta)
                .HasForeignKey(d => d.IdMedicamento)
                .HasConstraintName("FK_DETREC_MEDICAMENTO");

            entity.HasOne(d => d.IdRecetaNavigation).WithMany(p => p.DetalleReceta)
                .HasForeignKey(d => d.IdReceta)
                .HasConstraintName("FK_DETREC_RECETA");
        });

        modelBuilder.Entity<EfectoAdverso>(entity =>
        {
            entity.HasKey(e => e.IdEfecto);

            entity.ToTable("EFECTO_ADVERSO", "FARMACO");

            entity.Property(e => e.IdEfecto)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID_EFECTO");
            entity.Property(e => e.AjusteDosis)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AJUSTE_DOSIS");
            entity.Property(e => e.Descripcion)
                .HasColumnType("CLOB")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Dosis)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOSIS");
            entity.Property(e => e.DosisActual)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOSIS_ACTUAL");
            entity.Property(e => e.FechaFinEfecto)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_FIN_EFECTO");
            entity.Property(e => e.FechaInicioEfecto)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_INICIO_EFECTO");
            entity.Property(e => e.FechaReporte)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REPORTE");
            entity.Property(e => e.FechaSuspension)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_SUSPENSION");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_VENCIMIENTO");
            entity.Property(e => e.Gravedad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GRAVEDAD");
            entity.Property(e => e.IdMedicamento)
                .HasPrecision(10)
                .HasColumnName("ID_MEDICAMENTO");
            entity.Property(e => e.IdPaciente)
                .HasPrecision(19)
                .HasColumnName("ID_PACIENTE");
            entity.Property(e => e.Laboratorio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LABORATORIO");
            entity.Property(e => e.Lote)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOTE");
            entity.Property(e => e.MedidasTomadas)
                .HasColumnType("CLOB")
                .HasColumnName("MEDIDAS_TOMADAS");
            entity.Property(e => e.RegistroSanitario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("REGISTRO_SANITARIO");
            entity.Property(e => e.Suspension)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SUSPENSION");
            entity.Property(e => e.ViaAdministracion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VIA_ADMINISTRACION");

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.EfectoAdversos)
                .HasForeignKey(d => d.IdMedicamento)
                .HasConstraintName("FK_EFADV_MEDICAMENTO");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.EfectoAdversos)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK_EFADV_PACIENTE");
        });

        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.IdHistorial);

            entity.ToTable("HISTORIAL_MEDICO", "FARMACO");

            entity.Property(e => e.IdHistorial)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID_HISTORIAL");
            entity.Property(e => e.Diagnostico)
                .HasColumnType("CLOB")
                .HasColumnName("DIAGNOSTICO");
            entity.Property(e => e.Fecha)
                .HasColumnType("DATE")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdMedico)
                .HasPrecision(19)
                .HasColumnName("ID_MEDICO");
            entity.Property(e => e.IdPaciente)
                .HasPrecision(19)
                .HasColumnName("ID_PACIENTE");
            entity.Property(e => e.Tratamiento)
                .HasColumnType("CLOB")
                .HasColumnName("TRATAMIENTO");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK_HISTMED_PACIENTE");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento);

            entity.ToTable("MEDICAMENTO", "FARMACO");

            entity.Property(e => e.IdMedicamento)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID_MEDICAMENTO");
            entity.Property(e => e.Composicion)
                .HasColumnType("CLOB")
                .HasColumnName("COMPOSICION");
            entity.Property(e => e.Contraindicaciones)
                .HasColumnType("CLOB")
                .HasColumnName("CONTRAINDICACIONES");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Indicaciones)
                .HasColumnType("CLOB")
                .HasColumnName("INDICACIONES");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente);

            entity.ToTable("PACIENTE", "FARMACO");

            entity.Property(e => e.IdPaciente)
                .HasPrecision(19)
                .ValueGeneratedNever()
                .HasColumnName("ID_PACIENTE");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTACTO");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENERO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Recetum>(entity =>
        {
            entity.HasKey(e => e.IdReceta);

            entity.ToTable("RECETA", "FARMACO");

            entity.Property(e => e.IdReceta)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID_RECETA");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_EMISION");
            entity.Property(e => e.IdMedico)
                .HasPrecision(19)
                .HasColumnName("ID_MEDICO");
            entity.Property(e => e.IdPaciente)
                .HasPrecision(19)
                .HasColumnName("ID_PACIENTE");
            entity.Property(e => e.Observaciones)
                .HasColumnType("CLOB")
                .HasColumnName("OBSERVACIONES");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK_RECETA_PACIENTE");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
