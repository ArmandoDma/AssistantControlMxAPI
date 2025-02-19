using AssistsMx.Models;
using Microsoft.EntityFrameworkCore;
namespace AssistsMx.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "server=localhost;database=assitscontrolmx;user=root;password=BlAZ10tq20;port=3306";
                optionsBuilder.UseMySQL(connectionString);
            }
        }


        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Empleados> Empleados { get; set;}
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }  
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Vacaciones> Vacaciones { get; set; }
    }
}
