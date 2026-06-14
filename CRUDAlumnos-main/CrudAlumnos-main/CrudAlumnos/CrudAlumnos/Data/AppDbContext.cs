using Microsoft.EntityFrameworkCore;
using CrudAlumnos.Models;

namespace CrudAlumnos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .Property(a => a.Sexo)
                .HasColumnType("char(1)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
