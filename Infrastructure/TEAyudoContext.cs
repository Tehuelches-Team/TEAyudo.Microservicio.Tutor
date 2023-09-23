using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Tutores;
using Microsoft.Extensions.Options;

namespace TEAyudo_Tutores;
public class TEAyudoContext :DbContext
{

    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
 
    public TEAyudoContext(DbContextOptions<TEAyudoContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.ToTable("Tutor");
            entity.HasKey(t => t.TutorId);
            entity.Property(t => t.TutorId);
            entity.HasMany<Paciente>(t => t.Pacientes)
                .WithOne(p => p.Tutor)
                .HasForeignKey(p => p.TutorId);

        });

        modelBuilder.Entity<Paciente>(entity =>
        { 
            entity.ToTable("Paciente"); 
            entity.HasKey(p => p.PacienteId);
            entity.Property(p => p.PacienteId);
            entity.HasOne(p => p.Tutor)
            .WithMany(t => t.Pacientes) 
            .HasForeignKey(p => p.TutorId);
        });
    }


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=TEAyudo_Tutores;Trusted_Connection=True;TrustServerCertificate=True");
    }

}



