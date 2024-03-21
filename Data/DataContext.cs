using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistCadVisita.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Visita> Visitas { get; set; }

        public static implicit operator ControllerContext(DataContext v)
        {
            throw new NotImplementedException();
        }
        public DbSet<Visitante> Visitantes { get; set; }
    }
}
