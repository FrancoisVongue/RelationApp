using System;

namespace RelationApp.Models
{
    public class RelationViewModel : CreateRelationViewModel
    {
        public Guid Id { get; set; }
        
        public bool IsDisabled { get; set; }
    }
}
