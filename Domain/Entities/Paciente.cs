using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Paciente
{
    public long IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public long DPI { get; set; }

    public string Genero { get; set; } = null!;

    public string Contacto { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<EfectoAdverso> EfectoAdversos { get; set; } = new List<EfectoAdverso>();

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    public virtual ICollection<Recetum> Receta { get; set; } = new List<Recetum>();
}
