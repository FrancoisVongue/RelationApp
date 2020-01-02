using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using System.Net.Http;
using System.Linq;
using RelationApp.Models;
using System;
using System.Reflection;
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
            if (sortfield != null)
            {
                var _relations = _relationService.GetOrdered(sortfield);
                return View(_mapper.Map<IEnumerable<RelationViewModel>>(_relations));
            }

            var relations = _relationService.GetAll();
            return View(_mapper.Map<IEnumerable<RelationViewModel>>(relations));
        }

        public IActionResult Create(CreateRelationViewModel viewRelation)
        {
            if (HttpContext.Request.Method == HttpMethod.Get.Method)
            {
                return View();
            }

            var relation = _mapper.Map<Relation>(viewRelation);
            _relationService.Add(relation);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(EditRelationViewModel viewRelation)
        {
            Console.WriteLine(viewRelation.Id);
            var relation = _relationService.GetById(viewRelation.Id);
            var changedProperties = typeof(EditRelationViewModel).GetProperties();
            foreach (var property in changedProperties)
            {
                var changedValue = property.GetValue(viewRelation);
                var propertyOfTheRelation = typeof(Relation).GetProperty(property.Name);
                propertyOfTheRelation.SetValue(relation, changedValue);
            }

            _relationService.Update(relation);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            var domainRelation = _relationService.GetById(id);
            var relationToEdit = _mapper.Map<EditRelationViewModel>(domainRelation);
            return View(relationToEdit);
        }

        public IActionResult Delete(Guid id)
        {
            _relationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
