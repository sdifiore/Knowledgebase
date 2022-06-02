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

        [Authorize]
        public ActionResult Details(int? id)
        {
            return View();
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = _repository.GetFrameById(id);
            { }
            return View(model);
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
    }
}
