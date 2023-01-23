using Microsoft.EntityFrameworkCore;
using PruebaOh.Models;

namespace PruebaOh.Db
{
    public class DbEmpleadoDbContext: DbContext
    {
        public DbEmpleadoDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }

        public DbSet<Empleado> Empleados { get; set; }

    }
}
