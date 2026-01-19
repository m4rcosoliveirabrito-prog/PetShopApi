using Microsoft.AspNetCore.Mvc;
using PetShop.Entities;
using PetShop.Infra;

namespace PetShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly PetRepository _repo;

    public PetController(PetRepository repo)
    {
        _repo = repo;
    }

    // GET: api/pet
    [HttpGet]
    public async Task<ActionResult<List<Pet>>> GetAll()
    {
        var pets = await _repo.GetAllAsync();
        return Ok(pets);
    }

    // GET: api/pet/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Pet>> GetById([FromRoute] int id)
    {
        var pet = await _repo.GetByIdAsync(id);
        if (pet is null) return NotFound(new { mensagem = "Pet não encontrado." });

        return Ok(pet);
    }

    // POST: api/pet
    [HttpPost]
    public async Task<ActionResult<Pet>> Create([FromBody] Pet pet)
    {
        if (string.IsNullOrWhiteSpace(pet.Paciente))
            return BadRequest(new { mensagem = "Nome é obrigatório." });

        if (string.IsNullOrWhiteSpace(pet.Tipo))
            return BadRequest(new { mensagem = "Tipo é obrigatório (Gato/Cachorro)." });

        var criado = await _repo.CreateAsync(pet);

        return CreatedAtAction(nameof(GetById), new { id = criado.PetId }, criado);
    }

    // PUT: api/pet/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Pet pet)
    {
        if (string.IsNullOrWhiteSpace(pet.Paciente))
            return BadRequest(new { mensagem = "Nome é obrigatório." });

        if (string.IsNullOrWhiteSpace(pet.Tipo))
            return BadRequest(new { mensagem = "Tipo é obrigatório (Gato/Cachorro)." });

        var ok = await _repo.UpdateAsync(id, pet);
        if (!ok) return NotFound(new { mensagem = "Pet não encontrado." });

        return NoContent();
    }

    // DELETE: api/pet/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var ok = await _repo.DeleteAsync(id);
        if (!ok) return NotFound(new { mensagem = "Pet não encontrado." });

        return NoContent();
    }
}