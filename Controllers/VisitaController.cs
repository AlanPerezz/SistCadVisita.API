using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistCadVisita.API.Data;
namespace SistCadVisita.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitaController : ControllerBase
    {
        private readonly DataContext _context;

        public VisitaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visita>>> Get()
        {
            return await _context.Visitas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Visita>> GetById(int id)
        {
            var visita = await _context.Visitas.FindAsync(id);

            if (visita == null)
            {
                return NotFound();
            }

            return visita;
        }

        [HttpPost]
        public async Task<ActionResult<Visita>> Post([FromBody]Visita visita)
        {
            visita.Link = $"https://localhost:7078/api/visita/{visita.VisitaId}";

            _context.Visitas.Add(visita);
            await _context.SaveChangesAsync();

            _context.Entry(visita).State = EntityState.Modified;

            return CreatedAtAction(nameof(GetById), new { id = visita.VisitaId }, visita);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Visita visita)
        {

            _context.Entry(visita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(visita.VisitaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetById), new { id = visita.VisitaId }, visita);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var visita = await _context.Visitas.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            _context.Visitas.Remove(visita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitaExists(int id)
        {
            return _context.Visitas.Any(e => e.VisitaId == id);
        }
    }
}
