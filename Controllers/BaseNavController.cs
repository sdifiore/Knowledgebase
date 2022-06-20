using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knowledgebase.Data;
using Knowledgebase.Models;

namespace Knowledgebase.Controllers
{
    public class BaseNavController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseNavController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaseNav
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Framework.Include(f => f.PlataformaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BaseNav/Details/5
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

        // GET: BaseNav/Create
        public IActionResult Create()
        {
            ViewData["Plataforma"] = new SelectList(_context.Plataforma, "Id", "Id");
            return View();
        }

        // POST: BaseNav/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Plataforma,Apelido,Descricao,Versao")] Framework framework)
        {
            if (ModelState.IsValid)
            {
                _context.Add(framework);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Plataforma"] = new SelectList(_context.Plataforma, "Id", "Id", framework.Plataforma);
            return View(framework);
        }

        // GET: BaseNav/Edit/5
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

        // POST: BaseNav/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Plataforma,Apelido,Descricao,Versao")] Framework framework)
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
            ViewData["Plataforma"] = new SelectList(_context.Plataforma, "Id", "Id", framework.Plataforma);
            return View(framework);
        }

        // GET: BaseNav/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: BaseNav/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private bool FrameworkExists(int id)
        {
          return (_context.Framework?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
