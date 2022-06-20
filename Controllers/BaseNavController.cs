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


        // GET: BaseNav/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Framework == null)
            {
                return NotFound();
            }
            
            

            var frameworks = _context.Framework.Where(p => p.Plataforma == id);

            var framework = await _context.Framework.FindAsync(id);
            if (framework == null)
            {
                return NotFound();
            }
            ViewData["Plataforma"] = new SelectList(_context.Plataforma, "Id", "Descricao", framework.Plataforma);
            return View(framework);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Plataforma,Apelido,Descricao,Versao")] Framework framework)
        {

            var frameworks = _context.Framework.Select(p => p.Plataforma == framework.Id);
            ViewData["Framework"] = new SelectList(frameworks, "Id", "Descricao");

            return View(framework);
        }

        private bool FrameworkExists(int id)
        {
          return (_context.Framework?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
