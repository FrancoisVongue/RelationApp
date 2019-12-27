using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System.Net.Http;
using System.Linq;
using RelationApp.Models;

namespace RelationApp.Client.Controllers
{
    public class RelationController : Controller
    {
        private readonly IRelationService _service;

        private readonly IMapper _mapper;

        public RelationController(IRelationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var relations = _service.GetAll();
            var mappedRelations = relations
                .Select(relation => _mapper
                .Map<RelationViewModel>(relation));

            return View(relations);
        }
        
        [Route("Home/Index/sortfield")]
        public IActionResult Index(string sortfield)
        {
            return View(_service.GetOrdered(sortfield));
        }

        public IActionResult AddRelation(RelationViewModel relation)
        {
            if (HttpContext.Request.Method == HttpMethod.Post.Method)
            {
                var unMappedRelation = _mapper.Map<Relation>(relation);
                _service.Add(unMappedRelation);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
