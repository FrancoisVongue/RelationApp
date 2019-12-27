using Microsoft.AspNetCore.Mvc;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;

namespace RelationApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private IRelationService service;
        public HomeController(IRelationService s)
        {
            service = s;
        }

        public IActionResult Index() => View(service.GetAll());
        
        [Route("Home/Index/sortfield")]
        public IActionResult Index(string sortfield)
        {
            return View(service.GetOrdered(sortfield));
        }

        [HttpGet]
        public IActionResult AddRelation() => View();

        [HttpPost]
        public IActionResult AddRelation(Relation relation)
        {
            service.Add(relation);
            return RedirectToAction(nameof(Index));
        }
    }
}
