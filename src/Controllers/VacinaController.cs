using Microsoft.AspNetCore.Mvc;
using PetShop.Entities;
using PetshopApi.Infra;

namespace PetshopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacinaController : ControllerBase
{
    private readonly VacinaRepository _repo;

    public VacinaController(VacinaRepository repo)
    {
        _repo = repo;
    }

    // GET: api/vacina
    [HttpGet]
    public async Task<ActionResult<List<Vacina>>> GetAll()
    {
        var vacinas = await _repo.GetAllAsync();
        return Ok(vacinas);
    }

    // GET: api/vacina/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Vacina>> GetById([FromRoute] int id)
    {
        var vacina = await _repo.GetByIdAsync(id);
        if (vacina is null)
            return NotFound(new { mensagem = "Vacina não encontrada." });

        return Ok(vacina);
    }

    // POST: api/vacina
    [HttpPost]
    public async Task<ActionResult<Vacina>> Create([FromBody] Vacina vacina)
    {
        if (string.IsNullOrWhiteSpace(vacina.Nome))
            return BadRequest(new { mensagem = "Nome da vacina é obrigatório." });

        if (string.IsNullOrWhiteSpace(vacina.Description))
            return BadRequest(new { mensagem = "Descrição é obrigatória." });

        vacina.CreatedWhen = DateTime.Now;

        var criada = await _repo.CreateAsync(vacina);

        return CreatedAtAction(nameof(GetById), new { id = criada.VacinaId }, criada);
    }

    // PUT: api/vacina/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Vacina vacina)
    {
        if (string.IsNullOrWhiteSpace(vacina.Nome))
            return BadRequest(new { mensagem = "Nome da vacina é obrigatório." });

        if (string.IsNullOrWhiteSpace(vacina.Description))
            return BadRequest(new { mensagem = "Descrição é obrigatória." });

        var ok = await _repo.UpdateAsync(id, vacina);
        if (!ok)
            return NotFound(new { mensagem = "Vacina não encontrada." });

        return NoContent();
    }

    // DELETE: api/vacina/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var ok = await _repo.DeleteAsync(id);
        if (!ok)
            return NotFound(new { mensagem = "Vacina não encontrada." });

        return NoContent();
    }
}
