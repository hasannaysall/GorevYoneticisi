using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GorevYoneticisi.Data;
using GorevYoneticisi.Models;
namespace GorevYoneticisi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GorevYoneticisiContext _context;

        public UserController(GorevYoneticisiContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kullanici>>> GetKullanicilar()
        {
            return await _context.Kullanicilar.Include(k => k.Gorevler).ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Kullanici>> GetKullanici(int id)
        {
            var kullanici = await _context.Kullanicilar.Include(k => k.Gorevler).FirstOrDefaultAsync(k => k.Id == id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return kullanici;
        }

        
        [HttpPost]
        public async Task<ActionResult<Kullanici>> CreateKullanici(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKullanici), new { id = kullanici.Id }, kullanici);
        }
    }
}
