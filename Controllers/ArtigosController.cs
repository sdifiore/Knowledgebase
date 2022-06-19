using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knowledgebase.Data;
using Knowledgebase.Models;

namespace Knowledgebase.Controllers
{
    public class ArtigosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtigosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Artigos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Artigo.Include(a => a.Fonte);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Artigos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo
                .Include(a => a.Fonte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        // GET: Artigos/Create
        public IActionResult Create()
        {
            ViewData["FonteId"] = new SelectList(_context.Fonte, "Id", "Name");
            return View();
        }

        // POST: Artigos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Chamada,Corpo,FonteId")] Artigo artigo)
        {
            _context.Add(artigo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Artigos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo.FindAsync(id);
            if (artigo == null)
            {
                return NotFound();
            }
            ViewData["FonteId"] = new SelectList(_context.Fonte, "Id", "Name", artigo.FonteId);
            return View(artigo);
        }

        // POST: Artigos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Chamada,Corpo,FonteId")] Artigo artigo)
        {
            if (id != artigo.Id)
            {
                return NotFound();
            }

            _context.Update(artigo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Artigos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artigo == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo
                .Include(a => a.Fonte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        // POST: Artigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artigo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Artigo'  is null.");
            }
            var artigo = await _context.Artigo.FindAsync(id);
            if (artigo != null)
            {
                _context.Artigo.Remove(artigo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtigoExists(int id)
        {
          return (_context.Artigo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
