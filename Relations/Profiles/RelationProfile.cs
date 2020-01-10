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
            CreateMap<Relation, DisplayRelationViewModel>();

            CreateMap<Relation, CreateUpdateRelationViewModel>();

            CreateMap<CreateUpdateRelationViewModel, Relation>()
                .ConvertUsing(src => new Relation()
                {
                    Id = src.Id,
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
