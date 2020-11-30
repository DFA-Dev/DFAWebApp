using AutoMapper;
using DFAWebApp.API.Dtos;
using DFAWebApp.Domain.Models;

namespace DFAWebApp.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            // Domain to Resource
            CreateMap<UserModel, UserResultDto>().ReverseMap();

            //Resource to Domain
            CreateMap<UserResultDto, UserModel>().ReverseMap();
        }   
    }
}
