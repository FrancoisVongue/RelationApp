using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System.Net.Http;
using System.Linq;
using RelationApp.Models;
using System;

namespace RelationApp.Client.Controllers
{
    public class RelationController : Controller
    {
        private readonly IRelationService _relationService;

        private readonly IMapper _mapper;

        public RelationController(IRelationService rs, IMapper mapper)
        {
            _relationService = rs;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var relations = _relationService.GetAll();
            var mappedRelations = relations
                .Select(relation => _mapper
                .Map<RelationViewModel>(relation));

            return View(relations);
        }
        
        [Route("Home/Index/sortfield")]
        public IActionResult Index(string sortfield)
        {
            return View(_relationService.GetOrdered(sortfield));
        }

        public IActionResult AddRelation(CreateRelationViewModel view_relation)
        {
            if (HttpContext.Request.Method == HttpMethod.Post.Method)
            {
                var relation = _mapper.Map<Relation>(view_relation);
                _relationService.Add(relation);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(EditRelationViewModel view_relation)
        {
            if (HttpContext.Request.Method == HttpMethod.Post.Method)
            {
                //TODO add edit
            }
            else
            {
                return View();
            }
        }
    }
}
