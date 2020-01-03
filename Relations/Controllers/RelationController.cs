using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System.Net.Http;
using RelationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Index(string sortfield, string category)
        {
            ViewBag.Categories = _relationService.GetCategories();

            var relations = string.IsNullOrEmpty(category) ?
                _relationService.GetAll():
                _relationService.GetByCategory(category);

            if (string.IsNullOrEmpty(sortfield))
                _relationService.OrderByProperty(sortfield, relations);

            var viewRelations = _mapper.Map<IEnumerable<DisplayRelationViewModel>>(relations);
            return View(viewRelations);
        }

        public IActionResult Create(CreateUpdateRelationViewModel viewRelation)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.Method)
            {
                return View();
            }
            else if (ModelState.IsValid)
            {
                var relation = _mapper.Map<Relation>(viewRelation);
                _relationService.Add(relation);
                return RedirectToAction(nameof(Index));
            }
            else return View(viewRelation);
        }

        [HttpPost]
        public IActionResult Edit(CreateUpdateRelationViewModel viewRelation)
        {
            var relation = _mapper.Map<Relation>(viewRelation);
            _relationService.Update(relation);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            var domainRelation = _relationService.GetById(id);
            var relationToEdit = _mapper.Map<CreateUpdateRelationViewModel>(domainRelation);
            return View(relationToEdit);
        }

        public IActionResult Delete(Guid id)
        {
            _relationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}