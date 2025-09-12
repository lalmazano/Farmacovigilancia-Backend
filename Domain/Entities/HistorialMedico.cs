using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class HistorialMedico
{
    public int IdHistorial { get; set; }

    public long? IdPaciente { get; set; }

    public long? IdMedico { get; set; }

    public DateTime Fecha { get; set; }

    public string Diagnostico { get; set; } = null!;

    public string Tratamiento { get; set; } = null!;

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
