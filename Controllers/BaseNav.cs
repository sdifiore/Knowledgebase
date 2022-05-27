using KnowledgeBase.Models;

using Microsoft.AspNetCore.Authorization;
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


        [Authorize]
        public IActionResult NewFrame()
        {
            return View();
        }

        [Authorize]
        public IActionResult QuerySolutionChooseFrame()
        {
        var frameworks = _repository.GetAllFrameworksSorted();

        return View(frameworks);
        }

        [HttpPost]
        [Authorize]
        public ViewResult SearchFrame(string searchString)
        {
            var frameworks = _repository.SearchFrame(searchString);

            return View("QuerySolutionChooseFrame", frameworks);
        }
    }
}
