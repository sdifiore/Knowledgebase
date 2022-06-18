using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Models;
using Knowledgebase.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Knowledgebase.Controllers
{
    public class PlataformasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlataformasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plataformas
        public async Task<IActionResult> Index()
        {
              return _context.Plataformas != null ? 
                          View(await _context.Plataformas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Plataformas'  is null.");
        }

        // GET: Plataformas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plataformas == null)
            {
                return NotFound();
            }

            var plataforma = await _context.Plataformas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plataforma == null)
            {
                return NotFound();
            }

            return View(plataforma);
        }

        // GET: Plataformas/Create
        public IActionResult Create()
        {
            ViewData["Framework"] = new SelectList(_context.Frameworks, "Id", "Apelido");

            return View();
        }

        // POST: Plataformas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Apelido,Descricao,Versao")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plataforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plataforma);
        }

        // GET: Plataformas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plataformas == null)
            {
                return NotFound();
            }

            var plataforma = await _context.Plataformas.FindAsync(id);
            if (plataforma == null)
            {
                return NotFound();
            }
            return View(plataforma);
        }

        // POST: Plataformas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apelido,Descricao,Versao")] Plataforma plataforma)
        {
            if (id != plataforma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plataforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlataformaExists(plataforma.Id))
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
            return View(plataforma);
        }

        // GET: Plataformas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plataformas == null)
            {
                return NotFound();
            }

            var plataforma = await _context.Plataformas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plataforma == null)
            {
                return NotFound();
            }

            return View(plataforma);
        }

        // POST: Plataformas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plataformas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Plataformas'  is null.");
            }
            var plataforma = await _context.Plataformas.FindAsync(id);
            if (plataforma != null)
            {
                _context.Plataformas.Remove(plataforma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlataformaExists(int id)
        {
          return (_context.Plataformas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
