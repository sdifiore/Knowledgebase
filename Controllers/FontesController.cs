using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Models;
using Knowledgebase.Data;

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
              return _context.Fontes != null ? 
                          View(await _context.Fontes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Fontes'  is null.");
        }

        // GET: Fontes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fontes == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fontes
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
            return View();
        }

        // POST: Fontes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Fonte fonte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fonte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fonte);
        }

        // GET: Fontes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fontes == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fontes.FindAsync(id);
            if (fonte == null)
            {
                return NotFound();
            }
            return View(fonte);
        }

        // POST: Fontes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Fonte fonte)
        {
            if (id != fonte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fonte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FonteExists(fonte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fonte);
        }

        // GET: Fontes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fontes == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fontes
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
            if (_context.Fontes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fontes'  is null.");
            }
            var fonte = await _context.Fontes.FindAsync(id);
            if (fonte != null)
            {
                _context.Fontes.Remove(fonte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FonteExists(int id)
        {
          return (_context.Fontes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
