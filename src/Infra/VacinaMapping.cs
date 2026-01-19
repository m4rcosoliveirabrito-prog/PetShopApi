using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Entities;
using System.Reflection.Emit;

namespace PetShop.Infra;

public class VacinaMapping : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Vacina>(entity =>
        {

            entity.ToTable("Vacinas");

            entity.HasKey(c => c.VacinaId);

            entity.Property(c => c.Nome);

            entity.Property(c => c.Description)
                .HasColumnName("Description")
                .HasMaxLength(150);

            entity.Property(c => c.CreatedWhen)
                .IsRequired();
        });

    }
}