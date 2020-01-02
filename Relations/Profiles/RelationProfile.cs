using AutoMapper;
using RelationApp.Domain.Models;
using RelationApp.Models;
using RelationApp.Services;
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
                    Name = src.Name,
                    FullName = src.FullName,
                    TelephoneNumber = src.TelephoneNumber,
                    EmailAddress = src.EmailAddress,
                    DefaultCountry = src.DefaultCountry,
                    DefaultCity = src.DefaultCity,
                    DefaultStreet = src.DefaultStreet,
                    DefaultPostalCode = src.DefaultPostalCode,
                    IsDisabled = false,
                    CreatedAt = DateTime.Now,
                    IsTemporary = false,
                    IsMe = false,
                    PaymentViaAutomaticDebit = false,
                    InvoiceDateGenerationOptions = 0,
                    InvoiceGroupByOptions = 0,
                    CreatedBy = "User",
        
                });

            CreateMap<RelationViewModel, Relation>()
                .ConvertUsing(src => new Relation()
                {
                    Id = src.Id,
                    IsDisabled = src.IsDisabled,
                    Name = src.Name,
                    FullName = src.FullName,
                    TelephoneNumber = src.TelephoneNumber,
                    EmailAddress = src.EmailAddress,
                    DefaultCountry = src.DefaultCountry,
                    DefaultCity = src.DefaultCity,
                    DefaultStreet = src.DefaultStreet,
                    DefaultPostalCode = src.DefaultPostalCode,
                });
        }

    }
}
