using AutoMapper;
using RelationApp.Domain.Models;
using System.Collections.Generic;

namespace RelationApp.Models
{
    public class RelationViewModel : CreateRelationViewModel
    {
        public string Id { get; set; }
        
        public string IsDisabled { get; set; }
    }
}
