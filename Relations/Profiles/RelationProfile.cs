using AutoMapper;
using RelationApp.Domain.Models;
using RelationApp.Models;
using System;

namespace RelationApp.Profiles
{
    public class RelationProfile : Profile
    {
        public RelationProfile()
        {
            CreateMap<Relation, RelationViewModel>();
            CreateMap<CreateRelationViewModel, Relation>()
                .ConvertUsing(src => new Relation()
                {
                    // TODO : start here, i just added default properties
                    IsDisabled = false,

                    Name = src.Name,

                    FullName = src.FullName,

                    TelephoneNumber = src.TelephoneNumber,

                    EmailAddress = src.EmailAddress,

                    DefaultCountry = src.DefaultCountry,

                    DefaultCity = src.DefaultCity,

                    DefaultStreet = src.DefaultStreet,

                    DefaultPostalCode = src.DefaultPostalCode,
                    
                    Id = Guid.NewGuid(),
                    
                    CreatedAt = DateTime.Now,
                    
                    IsTemporary = false,
                    
                    IsMe = false,
                    
                    PaymentViaAutomaticDebit = false,
                    
                    InvoiceDateGenerationOptions = 0,
                    
                    InvoiceGroupByOptions = 0,
                    
                    CreatedBy = "User",
        });
        }
    }
}
