using AutoMapper;
using RelationApp.Domain.Models;
using System.Collections.Generic;

namespace RelationApp.Models
{
    public class CreateRelationViewModel
    {        
        public bool IsDisabled { get; set; }
        
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
