using Microsoft.EntityFrameworkCore;
namespace Dental_White.Moduls
{
    public class DentalWhiteContext : DbContext
    {
        public DentalWhiteContext(DbContextOptions<DentalWhiteContext> options):
        base(options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>()
            .HasMany<Paciente>(c => c.Pacientes)
            .WithOne(p => p.Cita)
            .HasForeignKey(p => p.CitaId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cita>()
            .HasMany<Doctor>(c => c.Doctores)
            .WithOne(d => d.Cita)
            .HasForeignKey(d => d.CitaId)
            .OnDelete(DeleteBehavior.Cascade);
        }*/
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<Hora> Horas {get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Cita> Citas { get; set; }

    }
}