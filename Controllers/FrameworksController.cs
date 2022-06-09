using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Models;
using Knowledgebase.Data;

namespace Knowledgebase.Controllers
{
    public class FrameworksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FrameworksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Frameworks
        public async Task<IActionResult> Index()
        {
              return _context.Frameworks != null ? 
                          View(await _context.Frameworks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Frameworks'  is null.");
        }

        // GET: Frameworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Frameworks == null)
            {
                return NotFound();
            }

            var framework = await _context.Frameworks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (framework == null)
            {
                return NotFound();
            }

            return View(framework);
        }

        // GET: Frameworks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frameworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Apelido,Descricao,Versao")] Framework framework)
        {
            if (ModelState.IsValid)
            {
                _context.Add(framework);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(framework);
        }

        // GET: Frameworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Frameworks == null)
            {
                return NotFound();
            }

            var framework = await _context.Frameworks.FindAsync(id);
            if (framework == null)
            {
                return NotFound();
            }
            return View(framework);
        }

        // POST: Frameworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apelido,Descricao,Versao")] Framework framework)
        {
            if (id != framework.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(framework);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrameworkExists(framework.Id))
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
            return View(framework);
        }

        // GET: Frameworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Frameworks == null)
            {
                return NotFound();
            }

            var framework = await _context.Frameworks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (framework == null)
            {
                return NotFound();
            }

            return View(framework);
        }

        // POST: Frameworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Frameworks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Frameworks'  is null.");
            }
            var framework = await _context.Frameworks.FindAsync(id);
            if (framework != null)
            {
                _context.Frameworks.Remove(framework);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrameworkExists(int id)
        {
          return (_context.Frameworks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
