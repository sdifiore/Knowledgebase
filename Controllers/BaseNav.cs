using KnowledgeBase.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


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
            var items = new List<SelectList>();
            var frameworks = _repository.GetFrameworks();

            foreach (var framework in frameworks)
            {
                items.Add(new SelectList($"{framework.Descricao} - Versão {framework.Versao}", framework.Id.ToString()));
            }

            return View(items);
        }
    }
}
