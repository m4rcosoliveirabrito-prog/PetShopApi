using Microsoft.EntityFrameworkCore;
using PetShop.Entities;

namespace PetShop.Infra;

public class CartaoVacinaRepository
{
    private readonly PetDbContext _context;

    public CartaoVacinaRepository(PetDbContext context)
    {
        _context = context;
    }

    public async Task<List<CartaoVacina>> GetAllAsync()
    {
        return await _context.CartaoVacina
            .AsNoTracking()
            .OrderByDescending(c => c.DataAplicacao)
            .ToListAsync();
    }

    public async Task<CartaoVacina?> GetByIdAsync(int id)
    {
        return await _context.CartaoVacina
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CartaoVacina> CreateAsync(CartaoVacina cartao)
    {
        _context.CartaoVacina.Add(cartao);
        await _context.SaveChangesAsync();
        return cartao;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var registro = await _context.CartaoVacina
            .FirstOrDefaultAsync(c => c.Id == id);

        if (registro is null) return false;

        _context.CartaoVacina.Remove(registro);
        await _context.SaveChangesAsync();
        return true;
    }
}
