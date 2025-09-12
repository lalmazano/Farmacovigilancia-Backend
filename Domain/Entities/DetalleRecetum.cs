using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DetalleRecetum
{
    public int IdDetalle { get; set; }

    public int? IdReceta { get; set; }

    public int? IdMedicamento { get; set; }

    public string Dosis { get; set; } = null!;

    public string Frecuencia { get; set; } = null!;

    public string Duracion { get; set; } = null!;

    public virtual Medicamento? IdMedicamentoNavigation { get; set; }

    public virtual Recetum? IdRecetaNavigation { get; set; }
}
