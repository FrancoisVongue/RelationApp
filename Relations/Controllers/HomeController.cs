using Microsoft.AspNetCore.Mvc;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System.Net.Http;

namespace RelationApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private IRelationService _service;

        public HomeController(IRelationService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var relations = _service.GetAll();
            return View(relations);
        }
        
        [Route("Home/Index/sortfield")]
        public IActionResult Index(string sortfield)
        {
            return View(_service.GetOrdered(sortfield));
        }

        public IActionResult AddRelation(Relation relation)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.Method)
            {
                return View();
            }
            else
            {
                _service.Add(relation);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
