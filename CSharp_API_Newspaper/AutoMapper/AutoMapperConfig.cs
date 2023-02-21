using AutoMapper;
using CSharp_API_Newspaper.Business.Services;
using CSharp_API_Newspaper.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_API_Newspaper.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperConfig()
        {
            // admin
            CreateMap<NP_Admin, AdminViewModel>().ForMember(dest => dest.Members,
                x => x.MapFrom(src => src.NP_Members))
                .ForMember(dest => dest.Birth,
                    opt => opt.MapFrom(src => $"{src.Birth.ToString("dd-MM-yyyy")}"));

            CreateMap<NP_Admin, AdminCreateUpdateModel>().ReverseMap();

            // member
            CreateMap<NP_Member, MemberViewModel>().ForMember(dest => dest.Birth,
                    opt => opt.MapFrom(src => $"{src.Birth.ToString("dd-MM-yyyy")}"));

            CreateMap<NP_Member, MemberCreateUpdateModel>().ReverseMap();
        }
    }
}
