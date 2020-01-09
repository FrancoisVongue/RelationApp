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
        private int rowsPerPage = 5;

        private readonly IMapper _mapper;

        public RelationController(IRelationService rs, IMapper mapper)
        {
            _relationService = rs;
            _mapper = mapper;
        }

        public IActionResult Index(string category, string sortfield, int page = 1)
        {
            var relations = _relationService.GetRelations(ref page, rowsPerPage, sortfield, category);
            var viewRelations = _mapper.Map<IEnumerable<DisplayRelationViewModel>>(relations);

            var info = new TableInfo()
            {
                CurrentPageNumber = page,
                AmountOfPages = _relationService.CountPages(rowsPerPage, category),
                Categories = _relationService.GetCategories(),
                Relations = viewRelations
            };

            return View(info);
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateRelationViewModel viewRelation)
        {
            if (ModelState.IsValid)
            {
                var relation = _mapper.Map<Relation>(viewRelation);
                _relationService.Add(relation);
                return RedirectToAction(nameof(Index));
            }
            
            return View(viewRelation);
        }
        
        public IActionResult Create()
        {
            return View();
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