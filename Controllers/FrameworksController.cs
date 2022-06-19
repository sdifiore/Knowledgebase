using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knowledgebase.Data;
using Knowledgebase.Models;

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
            var applicationDbContext = _context.Framework.Include(f => f.PlataformaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Frameworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Framework == null)
            {
                return NotFound();
            }

            var framework = await _context.Framework
                .Include(f => f.PlataformaNavigation)
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
            ViewData["Plataforma"] = new SelectList(_context.Plataforma, "Id", "ShowItem");
            return View();
        }

        // POST: Frameworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Framework framework)
        {
            _context.Add(framework);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Frameworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Framework == null)
            {
                return NotFound();
            }

            var framework = await _context.Framework.FindAsync(id);
            if (framework == null)
            {
                return NotFound();
            }
            ViewData["Plataforma"] = new SelectList(_context.Plataforma, "Id", "Id", framework.Plataforma);
            return View(framework);
        }

        // POST: Frameworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Framework framework)
        {
            if (id != framework.Id)
            {
                return NotFound();
            }

            {
                _context.Update(framework);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // GET: Frameworks/Delete/5
            async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.Framework == null)
                {
                    return NotFound();
                }

                var framework = await _context.Framework
                    .Include(f => f.PlataformaNavigation)
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
            async Task<IActionResult> DeleteConfirmed(int id)
            {
                if (_context.Framework == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Framework'  is null.");
                }
                var framework = await _context.Framework.FindAsync(id);
                if (framework != null)
                {
                    _context.Framework.Remove(framework);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            bool FrameworkExists(int id)
            {
                return (_context.Framework?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        }
    }
}
