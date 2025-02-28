using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GorevYoneticisi.Data;
using GorevYoneticisi.Models;
namespace GorevYoneticisi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly GorevYoneticisiContext _context;

        public TaskController(GorevYoneticisiContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gorev>>> GetGorevler()
        {
            return await _context.Gorevler.Include(g => g.Kullanici).ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<Gorev>> GetGorev(int id)
        {
            var gorev = await _context.Gorevler.Include(g => g.Kullanici).FirstOrDefaultAsync(g => g.Id == id);
            if (gorev == null)
            {
                return NotFound();
            }
            return gorev;
        }

        [HttpPost]
        public async Task<ActionResult<Gorev>> CreateGorev(Gorev gorev)
        {
            _context.Gorevler.Add(gorev);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGorev), new { id = gorev.Id }, gorev);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGorev(int id, Gorev gorev)
        {
            if (id != gorev.Id)
            {
                return BadRequest();
            }

            _context.Entry(gorev).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Gorevler.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGorev(int id)
        {
            var gorev = await _context.Gorevler.FindAsync(id);
            if (gorev == null)
            {
                return NotFound();
            }

            _context.Gorevler.Remove(gorev);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
