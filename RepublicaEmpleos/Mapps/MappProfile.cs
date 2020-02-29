using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RepublicaEmpleos.Models;

namespace RepublicaEmpleos.Mapps
{
    public class MappProfile:AutoMapper.Profile
    {
        public MappProfile()
        {
            CreateMap<Profile, FullProfileViewModel>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest =>
                    dest.Objetiv,
                    opt => opt.MapFrom(src => src.Objetiv))
                .ForMember(dest =>
                    dest.HeadHome,
                    opt => opt.MapFrom(src => src.HeadHome))
                .ForMember(dest =>
                    dest.ImagePath,
                    opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest =>
                    dest.GenderId,
                    opt => opt.MapFrom(src => src.GenderId))
                .ForMember(dest =>
                    dest.NationalityId,
                    opt => opt.MapFrom(src => src.NationalityId))
                .ForMember(dest =>
                    dest.MatiralStatusId,
                    opt => opt.MapFrom(src => src.MatiralStatusId))
                .ForMember(dest =>
                    dest.EducativeTitleId,
                    opt => opt.MapFrom(src => src.EducativeTitleId))
                .ForMember(dest =>
                    dest.ApplicationUserId,
                    opt => opt.MapFrom(src => src.ApplicationUserId))
                .ForMember(dest =>
                    dest.ProfileAddresses,
                    opt => opt.MapFrom(src => src.ProfileAddresses))
                .ForMember(dest =>
                    dest.ProfileEmails,
                    opt => opt.MapFrom(src => src.ProfileEmails))
                .ForMember(dest =>
                    dest.Phones,
                    opt => opt.MapFrom(src => src.Phones))
                .ForMember(dest =>
                    dest.ProfileVehicles,
                    opt => opt.MapFrom(src => src.ProfileVehicles))
                .ForMember(dest =>
                    dest.ProfileDocTypes,
                    opt => opt.MapFrom(src => src.ProfileDocTypes))
                .ReverseMap();

        }
    }
}
