using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCSharp.Data;
using ProjectCSharp.models;

namespace ProjectCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        // DI do banco
        public PersonagensController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        // Criar um novo item
        [HttpPost]
        public async Task<IActionResult> AddPersonagem(PersonagemDTO personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newPersonagem = new Personagem
            {
                Nome = personagem.Nome,
                Categoria = personagem.Categoria
            };

            this._appDbContext.DBZ.Add(newPersonagem);
            await this._appDbContext.SaveChangesAsync();

            return Created("Personagem adicionado com sucesso!", personagem);
        }  

        // Listar todos os items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> ShowPersonagem()
        {
            return await this._appDbContext.DBZ.ToListAsync();
        }

        // Listar um item específico
        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> ShowPersonagemById(int id)
        {
            var personagem = await _appDbContext.DBZ.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado!");
            }

            return Ok(personagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] PersonagemUpdate newPersonagem)
        {
            var personagem = await _appDbContext.DBZ.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado!");
            }

            if (newPersonagem.Nome != null)
            {
                personagem.Nome = newPersonagem.Nome!;
            }

            if (newPersonagem.Categoria != null)
            {
                personagem.Categoria = newPersonagem.Categoria!;
            }

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, personagem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagem = await _appDbContext.DBZ.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado!");
            }

            _appDbContext.DBZ.Remove(personagem);

            await _appDbContext.SaveChangesAsync();

            return Ok("Personagem deletado com sucesso.");
        }
    }
}