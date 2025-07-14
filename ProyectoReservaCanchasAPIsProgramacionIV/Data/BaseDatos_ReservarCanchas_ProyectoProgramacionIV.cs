using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Data
{
    public class BaseDatos_ReservarCanchas_ProyectoProgramacionIV : DbContext
    {
        public BaseDatos_ReservarCanchas_ProyectoProgramacionIV(DbContextOptions<BaseDatos_ReservarCanchas_ProyectoProgramacionIV> options)
            : base(options)
        {
        }

        public DbSet<Campus> Campus { get; set; } = default!;

        public DbSet<Administrador> Administrador { get; set; } = default!;
        public DbSet<Calendario> Calendario { get; set; } = default!;
        public DbSet<Cancha> Cancha { get; set; } = default!;
        public DbSet<Carrera> Carrera { get; set; } = default!;
        public DbSet<Estudiante> Estudiante { get; set; } = default!;
        public DbSet<Facultad> Facultad { get; set; } = default!;
        public DbSet<PersonalMantenimiento> PersonalMantenimiento { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Discriminador para herencia de PersonaUdla
            modelBuilder.Entity<PersonaUdla>()
                .HasDiscriminator<string>("TipoPersona")
                .HasValue<Estudiante>("Estudiante")
                .HasValue<Administrador>("Administrador")
                .HasValue<PersonalMantenimiento>("PersonalMantenimiento");
            // Relación de clave foránea solo para Administrador con Facultad
            modelBuilder.Entity<Administrador>()
                .HasOne(a => a.Facultad)
                .WithMany()  // No es necesario definir propiedad inversa en Facultad
                .HasForeignKey(a => a.FacultadId)
                .OnDelete(DeleteBehavior.Restrict);  // Para evitar eliminación en cascada si no se desea
        }

    }
}