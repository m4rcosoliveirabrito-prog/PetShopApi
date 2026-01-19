using Microsoft.AspNetCore.Mvc;
using PetShop.Entities;
using PetShop.Infra;

namespace PetShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartaoVacinaController : ControllerBase
{
    private readonly CartaoVacinaRepository _repo;

    public CartaoVacinaController(CartaoVacinaRepository repo)
    {
        _repo = repo;
    }

    // GET: api/cartaovacina
    [HttpGet]
    public async Task<ActionResult<List<CartaoVacina>>> GetAll()
    {
        return Ok(await _repo.GetAllAsync());
    }

    // GET: api/cartaovacina/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CartaoVacina>> GetById(int id)
    {
        var cartao = await _repo.GetByIdAsync(id);
        if (cartao is null)
            return NotFound(new { mensagem = "Registro não encontrado." });

        return Ok(cartao);
    }

    // POST: api/cartaovacina
    [HttpPost]
    public async Task<ActionResult<CartaoVacina>> Create([FromBody] CartaoVacina cartao)
    {
        if (cartao.PetId ==0)
            return BadRequest(new { mensagem = "Nome do paciente é obrigatório." });

        var criado = await _repo.CreateAsync(cartao);

        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    // DELETE: api/cartaovacina/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _repo.DeleteAsync(id);
        if (!ok)
            return NotFound(new { mensagem = "Registro não encontrado." });

        return NoContent();
    }
}