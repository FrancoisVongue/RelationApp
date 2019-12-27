using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApp.Models
{
    public class RelationViewModel
    {
        public string Id { get; set; }
        
        public string IsDisabled { get; set; }
        
        public string Name { get; set; }
        
        public string FullName { get; set; }
        
        public string TelephoneNumber { get; set; }
        
        public string EmailAddress { get; set; }
        
        public string DefaultCountry { get; set; }
        
        public string DefaultCity { get; set; }
        
        public string DefaultStreet { get; set; }
        
        public string DefaultPostalCode { get; set; }
    }
}
