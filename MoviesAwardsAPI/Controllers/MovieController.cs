using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAwardsAPI.Models;
using MoviesAwardsAPI.Models.Context;

namespace MoviesAwardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesAwardsDbContext _context;

        public MovieController(MoviesAwardsDbContext context)
        {
            _context = context;
        }

        // GET: api/Titles
        [HttpGet]
        public async Task<IEnumerable<Title>> GetAllTitles()
        {
            return await _context.Title.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitle(int id)
        {

            var title = await _context.Title.Include(a => a.Awards)
                 .Include(s => s.StoryLines).Include(p => p.TitleParticipants)
                .Include(g => g.TitleGenres).ThenInclude(tg => tg.Genre)
                .Include(p => p.TitleParticipants).ThenInclude(tp => tp.Participant)
                .FirstOrDefaultAsync(e => e.TitleId == id);

            if (title == null)
            {
                return NotFound();
            }

            return title;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(int id, Title title)
        {
            if (id != title.TitleId)
            {
                return BadRequest();
            }

            _context.Entry(title).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Title>> PostTitle(Title title)
        {
            _context.Title.Add(title);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitle", new { id = title.TitleId }, title);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(int id)
        {
            var title = await _context.Title.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            _context.Title.Remove(title);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TitleExists(int id)
        {
            return _context.Title.Any(e => e.TitleId == id);
        }
    }
}
