using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistCadVisita.API.Data;
namespace SistCadVisita.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitanteController : ControllerBase
    {
        private readonly DataContext _context;

        public VisitanteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitante>>> Get()
        {
            return await _context.Visitantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Visitante>> GetById(int id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);

            if (visitante == null)
            {
                return NotFound();
            }

            return visitante;
        }

        [HttpGet("visita/{id}")]
        public async Task<ActionResult<IEnumerable<Visitante>>> GetByVisitaId(int id)
        {
            var visitante = await _context.Visitantes.ToListAsync();
            visitante = visitante.Where(x => x.VisitaId == id).ToList();

            if (visitante == null)
            {
                return NotFound();
            }

            return visitante;
        }

        [HttpPost]
        public async Task<ActionResult<Visitante>> Post([FromBody] Visitante visitante)
        {
            _context.Visitantes.Add(visitante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = visitante.VisitanteId }, visitante);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Visitante visitante)
        {

            _context.Entry(visitante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitanteExists(visitante.VisitanteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetById), new { id = visitante.VisitanteId }, visitante);
        }

        [HttpPut("concluir")]
        public async Task<IActionResult> Concluir([FromBody] Visitante visitante)
        {

            _context.Entry(visitante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitanteExists(visitante.VisitanteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetById), new { id = visitante.VisitanteId }, visitante);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }

            _context.Visitantes.Remove(visitante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitanteExists(int id)
        {
            return _context.Visitantes.Any(e => e.VisitanteId == id);
        }
    }
}
