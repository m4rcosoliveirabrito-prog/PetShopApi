using Microsoft.EntityFrameworkCore;
using PetShop.Entities;

namespace PetShop.Infra;

public class CartaoVacinaMapping : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CartaoVacina>(entity =>
        {
            entity.ToTable("CartoesVacina");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.PetId)
            .IsRequired()
            .HasMaxLength(30);

            entity.Property(c => c.VacinaId);

            entity.Property(c => c.DataAplicacao)
            .IsRequired();

            entity.Property(c => c.CriadoEm)
                .IsRequired();

        });
    }
}
