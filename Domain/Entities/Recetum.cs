using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Recetum
{
    public decimal IdReceta { get; set; }

    public decimal? IdPaciente { get; set; }

    public decimal? IdMedico { get; set; }

    public DateTime FechaEmision { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<DetalleRecetum> DetalleReceta { get; set; } = new List<DetalleRecetum>();

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
