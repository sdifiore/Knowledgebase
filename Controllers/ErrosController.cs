using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knowledgebase.Data;
using Knowledgebase.Models;

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
            var applicationDbContext = _context.Erro.Include(e => e.Framework);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Erros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Erro == null)
            {
                return NotFound();
            }

            var erro = await _context.Erro
                .Include(e => e.Framework)
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
            ViewData["FrameworkId"] = new SelectList(_context.Framework, "Id", "ShowItem");
            return View();
        }

        // POST: Erros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Codigo,FrameworkId")] Erro erro)
        {
            _context.Add(erro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Erros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Erro == null)
            {
                return NotFound();
            }

            var erro = await _context.Erro.FindAsync(id);
            if (erro == null)
            {
                return NotFound();
            }
            ViewData["FrameworkId"] = new SelectList(_context.Framework, "Id", "Id", erro.FrameworkId);
            return View(erro);
        }

        // POST: Erros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Codigo,FrameworkId")] Erro erro)
        {
            if (id != erro.Id)
            {
                return NotFound();
            }

            _context.Update(erro);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Erros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Erro == null)
            {
                return NotFound();
            }

            var erro = await _context.Erro
                .Include(e => e.Framework)
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
            if (_context.Erro == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Erro'  is null.");
            }
            var erro = await _context.Erro.FindAsync(id);
            if (erro != null)
            {
                _context.Erro.Remove(erro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErroExists(int id)
        {
          return (_context.Erro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
