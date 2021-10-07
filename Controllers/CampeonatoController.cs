using System.Threading.Tasks;
using campeonato.Context;
using campeonato.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace campeonato.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/classificacao_geral")]
    public class CampeonatoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CampeonatoController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampeonato(int id)
        {
            var campeonato = await _context.Campeonatos.FindAsync(id);

            if (campeonato == null) return NotFound();
            
            return Ok(campeonato);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Campeonato campeonato)
        {
            _context.Campeonatos.Add(campeonato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampeonato", new { id = campeonato.Id }, campeonato);
        }
    }
}
