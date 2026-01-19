using Microsoft.EntityFrameworkCore;
using PetShop.Entities;

namespace PetShop.Infra;

public class PetMapping : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>(entity =>
        {
            entity.ToTable("Pets");
            entity.HasKey(p => p.PetId);

            entity.Property(p => p.Paciente)
                .IsRequired()
                .HasMaxLength(120);

            entity.Property(p => p.Tipo)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(p => p.Raca)
                .HasMaxLength(80);

            entity.Property(p => p.CriadoEm)
                .IsRequired();
        });
    }
}