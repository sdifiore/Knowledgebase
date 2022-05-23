using KnowledgeBase.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KnowledgeBase.Controllers
{
    public class BaseNav : Controller
    {
        private readonly IRepository _repository;

        public BaseNav(IRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult NewFrame()
        {
            return View();
        }

        public IActionResult QuerySolutionChooseFrame()
        {
        var frameworks = _repository.GetFrameworks();
        var items = new SelectList(frameworks, "Id", "Descricao");

            return View(items);
        }
    }
}
