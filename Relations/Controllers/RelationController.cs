using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System.Net.Http;
using RelationApp.Models;
using System;
using System.Collections.Generic;

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

        public IActionResult Index(string sortfield)
        {
            IEnumerable<Relation> relations;
            if (sortfield != null)
            {
                relations = _relationService.GetOrdered(sortfield);
            }
            else
            {
                relations = _relationService.GetAll();  
            }

            return View(_mapper.Map<IEnumerable<RelationViewModel>>(relations));
        }

        public IActionResult Create(CreateRelationViewModel viewRelation)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.Method)
            {
                return View();
            }
            _relationService.Add(_mapper.Map<Relation>(viewRelation));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(RelationViewModel viewRelation)
        {
            _relationService.Update(_mapper.Map<Relation>(viewRelation));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            var domainRelation = _relationService.GetById(id);
            var relationToEdit = _mapper.Map<RelationViewModel>(domainRelation);
            return View(relationToEdit);
        }

        public IActionResult Delete(Guid id)
        {
            _relationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}