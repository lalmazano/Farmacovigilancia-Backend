using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CrearEfectoAdversoDto
    {
        public long idPaciente { get; set; }         // int64
        public int idMedicamento { get; set; }      // int32

        [Required] public DateTime fechaReporte { get; set; }
        public string? descripcion { get; set; }

        public string? gravedad { get; set; }                    // "Leve" | "Moderada" | "Grave" | "Mortal" (según tú)

        public string? lote { get; set; } 
        public string? laboratorio { get; set; }
        public string? registroSanitario { get; set; } = null!;
        [Required] public DateTime fechaVencimiento { get; set; }

        public string? dosis { get; set; }

        public DateTime? fechaInicioEfecto { get; set; }
        public DateTime? fechaFinEfecto { get; set; }
        public string? viaAdministracion { get; set; }
        public string? medidasTomadas { get; set; }

        // En tu entidad son string → en el DTO también string
        public string? suspension { get; set; }      // "true"/"false" o "SI"/"NO" según tu regla
        public DateTime? fechaSuspension { get; set; }
        public string? ajusteDosis { get; set; }     // "true"/"false"
        public string? dosisActual { get; set; }
    }

    public sealed class ActualizarEfectoAdversoDto : CrearEfectoAdversoDto
    {
        [Required] public int IdEfecto { get; set; }
    }
}
