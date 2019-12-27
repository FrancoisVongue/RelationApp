using Microsoft.AspNetCore.Mvc;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System.Net.Http;

namespace RelationApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private IRelationService service;

        public HomeController(IRelationService s)
        {
            service = s;
        }

        public IActionResult Index()
        {
            var relations = service.GetAll();
            return View(relations);
        }
        
        [Route("Home/Index/sortfield")]
        public IActionResult Index(string sortfield)
        {
            return View(service.GetOrdered(sortfield));
        }

        public IActionResult AddRelation(Relation relation)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.Method)
            {
                return View();
            }
            else
            {
                service.Add(relation);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
