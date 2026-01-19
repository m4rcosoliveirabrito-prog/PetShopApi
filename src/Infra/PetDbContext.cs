using Microsoft.EntityFrameworkCore;
using PetShop.Entities;

namespace PetShop.Infra;

public class PetDbContext : DbContext
{
    public PetDbContext(DbContextOptions<PetDbContext> options) : base(options) { }

    public DbSet<Pet> Pet => Set<Pet>();
    public DbSet<Vacina> Vacinas => Set<Vacina>();
    public DbSet<CartaoVacina> CartaoVacina => Set<CartaoVacina>();
}