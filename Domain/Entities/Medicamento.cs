using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    public string Nombre { get; set; } = null!;

    public string Composicion { get; set; } = null!;

    public string Indicaciones { get; set; } = null!;

    public string Contraindicaciones { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<DetalleRecetum> DetalleReceta { get; set; } = new List<DetalleRecetum>();

    public virtual ICollection<EfectoAdverso> EfectoAdversos { get; set; } = new List<EfectoAdverso>();
}
