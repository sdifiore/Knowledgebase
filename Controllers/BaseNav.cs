using Knowledgebase.Data;

using KnowledgeBase.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Controllers
{
    public class BaseNav : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;

        public BaseNav(ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }


        [Authorize]
        public IActionResult NewFrame()
        {
            return View();
        }

        public IActionResult SaveNewFrame(Framework framework)
        {
            _repository.SaveNewFrame(framework);

            return RedirectToAction("QuerySolutionChooseFrame");
        }


        [Authorize]
        public ActionResult Delete(int? id)
        {
            return View();
        }

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
                return RedirectToAction(nameof(QuerySolutionChooseFrame));
            }
            return View(framework);
        }


        [Authorize]
        public IActionResult QuerySolutionChooseFrame()
        {
            var frameworks = _repository.GetAllFrameworksSorted();

            return View(frameworks);
        }

        [HttpPost]
        [Authorize]
        public IActionResult SearchFrame(string searchString)
        {
            var frameworks = _repository.SearchFrame(searchString);

            return View("QuerySolutionChooseFrame", frameworks);
        }

        private bool FrameworkExists(int id)
        {
            return (_context.Frameworks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}