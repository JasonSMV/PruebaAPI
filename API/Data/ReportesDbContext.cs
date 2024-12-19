using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ReportesDbContext : DbContext
    {
        public ReportesDbContext(DbContextOptions<ReportesDbContext> options) : base(options)
        {
        }

        public DbSet<ReporteValidacion> ReporteValidaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}