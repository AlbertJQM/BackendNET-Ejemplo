using System.ComponentModel.DataAnnotations;

namespace BackendNET_Ejemplo.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Creador { get; set; }
        [Required]
        public string Texto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
    }
}
