using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knowledgebase.Data;
using Knowledgebase.Models;

namespace Knowledgebase.Controllers
{
    public class FontesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FontesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fontes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fonte.Include(f => f.Erro);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fontes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fonte == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fonte
                .Include(f => f.Erro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fonte == null)
            {
                return NotFound();
            }

            return View(fonte);
        }

        // GET: Fontes/Create
        public IActionResult Create()
        {
            ViewData["ErroId"] = new SelectList(_context.Erro, "Id", "Nome");
            return View();
        }

        // POST: Fontes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ErroId")] Fonte fonte)
        {
            _context.Add(fonte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Fontes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fonte == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fonte.FindAsync(id);
            if (fonte == null)
            {
                return NotFound();
            }
            ViewData["ErroId"] = new SelectList(_context.Erro, "Id", "Codigo", fonte.ErroId);
            return View(fonte);
        }

        // POST: Fontes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ErroId")] Fonte fonte)
        {
            if (id != fonte.Id)
            {
                return NotFound();
            }

            _context.Update(fonte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Fontes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fonte == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fonte
                .Include(f => f.Erro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fonte == null)
            {
                return NotFound();
            }

            return View(fonte);
        }

        // POST: Fontes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fonte == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fonte'  is null.");
            }
            var fonte = await _context.Fonte.FindAsync(id);
            if (fonte != null)
            {
                _context.Fonte.Remove(fonte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FonteExists(int id)
        {
          return (_context.Fonte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
