using AutoMapper;
using RelationApp.Domain.Models;
using System.Collections.Generic;

namespace RelationApp.Models
{
    public class UpdateRelationViewModel : CreateRelationViewModel
    {
        public string Id { get; set; }
    }
}
