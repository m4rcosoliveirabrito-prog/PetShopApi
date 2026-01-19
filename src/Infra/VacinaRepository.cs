using Microsoft.EntityFrameworkCore;
using PetShop.Entities;
using PetShop.Infra;

namespace PetshopApi.Infra;

public class VacinaRepository
{
    private readonly PetDbContext _context;

    public VacinaRepository(PetDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vacina>> GetAllAsync()
    {
        return await _context.Vacinas
            .AsNoTracking()
            .OrderBy(v => v.VacinaId)
            .ToListAsync();
    }

    public async Task<Vacina?> GetByIdAsync(int id)
    {
        return await _context.Vacinas
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.VacinaId == id);
    }

    public async Task<Vacina> CreateAsync(Vacina vacina)
    {
        _context.Vacinas.Add(vacina);
        await _context.SaveChangesAsync();
        return vacina;
    }

    public async Task<bool> UpdateAsync(int id, Vacina vacinaAtualizada)
    {
        var vacina = await _context.Vacinas.FirstOrDefaultAsync(v => v.VacinaId == id);
        if (vacina is null) return false;

        vacina.Nome = vacinaAtualizada.Nome;
        vacina.Description = vacinaAtualizada.Description;
        vacina.CreatedWhen = vacinaAtualizada.CreatedWhen;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var vacina = await _context.Vacinas.FirstOrDefaultAsync(v => v.VacinaId == id);
        if (vacina is null) return false;

        _context.Vacinas.Remove(vacina);
        await _context.SaveChangesAsync();
        return true;
    }
}
