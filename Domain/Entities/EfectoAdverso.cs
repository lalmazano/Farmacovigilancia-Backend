using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class EfectoAdverso
{
    public int IdEfecto { get; set; }

    public long? IdPaciente { get; set; }

    public int? IdMedicamento { get; set; }

    public DateTime FechaReporte { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Gravedad { get; set; } = null!;

    public string Lote { get; set; } = null!;

    public string Laboratorio { get; set; } = null!;

    public string RegistroSanitario { get; set; } = null!;

    public DateTime FechaVencimiento { get; set; }

    public string? Dosis { get; set; }

    public DateTime? FechaInicioEfecto { get; set; }

    public DateTime? FechaFinEfecto { get; set; }

    public string? ViaAdministracion { get; set; }

    public string? MedidasTomadas { get; set; }

    public string? Suspension { get; set; }

    public DateTime? FechaSuspension { get; set; }

    public string? AjusteDosis { get; set; }

    public string? DosisActual { get; set; }

    public virtual Medicamento? IdMedicamentoNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
