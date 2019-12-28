using AutoMapper;
using RelationApp.Domain.Models;
using RelationApp.Models;
using RelationApp.Services;
using System;

namespace RelationApp.Profiles
{
    public class RelationProfile : Profile
    {
        public RelationProfile(RelationService service)
        {
            CreateMap<Relation, RelationViewModel>();
            CreateMap<CreateRelationViewModel, Relation>()
                .ConvertUsing(src => new Relation()
                {
                    IsDisabled = false,

                    // TODO : delete this comment Id = Guid.NewGuid(),
                    
                    Name = src.Name,

                    FullName = src.FullName,

                    TelephoneNumber = src.TelephoneNumber,

                    EmailAddress = src.EmailAddress,

                    DefaultCountry = src.DefaultCountry,

                    DefaultCity = src.DefaultCity,

                    DefaultStreet = src.DefaultStreet,

                    DefaultPostalCode = src.DefaultPostalCode,
                    
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
