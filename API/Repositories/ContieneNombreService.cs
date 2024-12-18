using API.Data;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ContieneNombreService : IContieneNombreService
    {
        private readonly ReportesDbContext _db;

        public ContieneNombreService(ReportesDbContext db)
        {
            this._db = db;
        }

        public bool ContieneNombre(string[] matrix, string nombre)
        {
            int filas = matrix.Length;
            int columnas = matrix[0].Length;
            int tamanio = nombre.Length;

            // se revisa horizontalmente
            for(int i = 0; i < filas; i++)
            {
                for(int j = 0; j <= columnas - tamanio; j++)
                {
                    if(matrix[i].Substring(j, tamanio) == nombre)
                    {
                        return true;
                    }
                }
            }

            // se revisa verticalment
            for(int i = 0; i < columnas; i++)
            {
                for(int j = 0; j <= filas - tamanio; j++)
                {
                    string vertical = "";
                    for(int k = 0; k < tamanio; k++)
                    {
                        vertical += matrix[j + k][i];
                    }
                    if(vertical == nombre)
                    {
                        return true;
                    }
                }
            }

            // se revisa diagonal principal: \
            for(int i = 0; i <= filas - tamanio; i++)
            {
                for(int j = 0; j <= columnas - tamanio; j++)
                {
                    string diagonal = "";
                    for(int k = 0; k < tamanio; k++)
                    {
                        diagonal += matrix[i + k][j + k];
                    }
                    if(diagonal == nombre)
                    {
                        return true;
                    }
                }
            }

            // se revisa diagonal inversa: /
            for(int i = tamanio - 1; i < filas; i++)
            {
                for(int j = 0; j <= columnas - tamanio; j++)
                {
                    string diagonal = "";
                    for(int k = 0; k < tamanio; k++)
                    {
                        diagonal += matrix[i - k][j + k];
                    }
                    if(diagonal == nombre)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<ReporteResponse> EstadisticasAsync()
        {
            int totalReportesConRespuestaPositiva = await _db.ReporteValidaciones.CountAsync(v => v.Resultado);
            int totalReportesConRepuestaNegativa = await _db.ReporteValidaciones.CountAsync(v => !v.Resultado);

            return new ReporteResponse
            {
                CuentaContieneNombre = totalReportesConRespuestaPositiva,
                CuentaNoContieneNombre = totalReportesConRepuestaNegativa,
                Relacion = totalReportesConRespuestaPositiva / (double)(totalReportesConRespuestaPositiva + totalReportesConRepuestaNegativa)
            };
        }

        public async Task CargarValidacionAsync(string[] info, string nombre, bool resultado)
        {
            var log = new ReporteValidacion
            {
                Matriz = string.Join("\n", info),
                Nombre = nombre,
                Resultado = resultado,
                Fecha = DateTime.UtcNow
            };

            _db.ReporteValidaciones.Add(log);
            await _db.SaveChangesAsync();
        }
    }
}