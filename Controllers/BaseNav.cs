using Knowledgebase.Data;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class BaseNav : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseNav(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult NewFrame()
        {
            return View();
        }

        public IActionResult QuerySolutionChooseFrame()
        {
            var frameworks = _context.Frameworks.ToList();

            return View(frameworks);
        }
    }
}
