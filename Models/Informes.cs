
using System.ComponentModel.DataAnnotations;
namespace CongReports.Models
{
    public class Informe
    {
        public int Id { get; set; }

        public int PublicadorId { get; set; }
        public Publicador Publicador { get; set; }

        public int? Publicaciones { get; set; }
        public int? Videos { get; set; }

        public int Horas { get; set; }
        public int? Revisitas { get; set; }
        [Display(Name = "Estudios Biblicos")]
        public int? Estudios { get; set; }

        public string? Notas { get; set; }

        [Display(Name = "Precursor Auxiliar")]
        public bool? PrecursorAuxiliar { get; set; }
    }
}
