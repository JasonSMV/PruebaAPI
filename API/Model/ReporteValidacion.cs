namespace API.Model
{
    public class ReporteValidacion
    {
        public int Id { get; set; }
        public string Matriz { get; set; }
        public string Nombre { get; set; }
        public bool Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }
}