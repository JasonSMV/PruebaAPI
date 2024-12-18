using API.Model;

namespace API.Repositories
{
    public interface IContieneNombreService
    {
        bool ContieneNombre(string[] info, string nombre);

        Task CargarValidacionAsync(string[] info, string nombre, bool resultado);

        Task<ReporteResponse> EstadisticasAsync();
    }
}