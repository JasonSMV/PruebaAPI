using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class ReporteValidacion
    {
        [Required]
        public int Id { get; set; }
        public string Matriz { get; set; }
        public string Nombre { get; set; }
        public bool Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }
}