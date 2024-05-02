using System.ComponentModel.DataAnnotations;

namespace Jossue_Ayala.Models
{
    public class Carrera
    {
        [Key]
        public int IdCarrera { get; set; }
        [Required]
        public String Nombre_Carrera { get; set; }

        public String Campus { get; set; }

        public int Numero_Semestres { get; set; }
    }
}
