using System.Threading.Tasks;
using campeonato.Entities;
using campeonato.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace campeonato.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/classificacao_geral")]
    public class CampeonatoController : ControllerBase
    {        
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoController(ICampeonatoService campeonatoService)
        {     
            _campeonatoService = campeonatoService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampeonato(int id)
        {
            var campeonato = await _campeonatoService.GetCampeonato(id);

            if (campeonato == null) return NotFound();
            
            return Ok(campeonato);
        }

        [HttpPost]
        public async Task<IActionResult> AddCampeonato(Campeonato campeonato)
        {
            await _campeonatoService.AddCampeonato(campeonato);          

            return CreatedAtAction("GetCampeonato", new { id = campeonato.Id }, campeonato);
        }
    }
}
