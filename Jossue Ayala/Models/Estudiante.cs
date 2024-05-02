using System.ComponentModel.DataAnnotations;

namespace Jossue_Ayala.Models
{
    public class Estudiante
    {
        [Key]
        public int Banner{ get; set; }
        [Required]
        public string Nombre { get; set; }

        public bool PasarSemestre { get; set; }

        public DateTime Fecha { get; set; }





    }
}
