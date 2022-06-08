using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Models;
using Knowledgebase.Data;

namespace Knowledgebase.Controllers
{
    public class ErrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ErrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Erros
        public async Task<IActionResult> Index()
        {
              return _context.Erros != null ? 
                          View(await _context.Erros.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Erros'  is null.");
        }

        // GET: Erros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Erros == null)
            {
                return NotFound();
            }

            var erro = await _context.Erros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erro == null)
            {
                return NotFound();
            }

            return View(erro);
        }

        // GET: Erros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Erros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Codigo,Fonte")] Erro erro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(erro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erro);
        }

        // GET: Erros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Erros == null)
            {
                return NotFound();
            }

            var erro = await _context.Erros.FindAsync(id);
            if (erro == null)
            {
                return NotFound();
            }
            return View(erro);
        }

        // POST: Erros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Codigo,Fonte")] Erro erro)
        {
            if (id != erro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(erro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErroExists(erro.Id))
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
            return View(erro);
        }

        // GET: Erros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Erros == null)
            {
                return NotFound();
            }

            var erro = await _context.Erros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erro == null)
            {
                return NotFound();
            }

            return View(erro);
        }

        // POST: Erros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Erros == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Erros'  is null.");
            }
            var erro = await _context.Erros.FindAsync(id);
            if (erro != null)
            {
                _context.Erros.Remove(erro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErroExists(int id)
        {
          return (_context.Erros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
