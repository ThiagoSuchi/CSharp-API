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

        [HttpPost]
        public async Task<IActionResult> AddPersonagem(Personagem personagem)
        {
            this._appDbContext.DBZ.Add(personagem);
            await this._appDbContext.SaveChangesAsync();

            return Ok(personagem);
        }  

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> ShowPersonagem()
        {
            return await this._appDbContext.DBZ.ToListAsync();
        }
    }
}