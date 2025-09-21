using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DetalleRecetum
{
    public decimal IdDetalle { get; set; }

    public decimal? IdReceta { get; set; }

    public decimal? IdMedicamento { get; set; }

    public string Dosis { get; set; } = null!;

    public string Frecuencia { get; set; } = null!;

    public string Duracion { get; set; } = null!;

    public virtual Medicamento? IdMedicamentoNavigation { get; set; }

    public virtual Recetum? IdRecetaNavigation { get; set; }
}
