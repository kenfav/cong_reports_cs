using System.ComponentModel.DataAnnotations;

namespace CongReports.Models
{
    public class Publicador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Fecha de Bautismo")]
        public DateTime? FechaBautismo { get; set; }
        [Display(Name = "Ungido")]
        public bool EsUngido { get; set; }
        [Display(Name = "Anciano")]
        public bool EsAnciano { get; set; }
        [Display(Name = "Siervo Ministerial")]
        public bool EsSiervoMinisterial { get; set; }
        [Display(Name = "Precursor Regular")]
        public bool EsPrecursor { get; set; }
    }
}
