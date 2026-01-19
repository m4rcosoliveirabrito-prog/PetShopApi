using Microsoft.EntityFrameworkCore;
using PetShop.Entities;

namespace PetShop.Infra;

public class PetRepository
{
    private readonly PetDbContext _context;

    public PetRepository(PetDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pet>> GetAllAsync()
    {
        return await _context.Pet
            .AsNoTracking()
            .OrderBy(p => p.PetId)
            .ToListAsync();
    }

    public async Task<Pet?> GetByIdAsync(int id)
    {
        return await _context.Pet
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PetId == id);
    }

    public async Task<Pet> CreateAsync(Pet pet)
    {
        _context.Pet.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task<bool> UpdateAsync(int id, Pet petAtualizado)
    {
        var pet = await _context.Pet.FirstOrDefaultAsync(p => p.PetId == id);
        if (pet is null) return false;

        pet.Paciente = petAtualizado.Paciente;
        pet.Tipo = petAtualizado.Tipo;
        pet.Raca = petAtualizado.Raca;
        pet.Idade = petAtualizado.Idade;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pet = await _context.Pet.FirstOrDefaultAsync(p => p.PetId == id);
        if (pet is null) return false;

        _context.Pet.Remove(pet);
        await _context.SaveChangesAsync();
        return true;
    }
}