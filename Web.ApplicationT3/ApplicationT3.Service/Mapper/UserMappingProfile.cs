using ApplicationT3.Domain.Models;
using ApplicationT3.Service.DTOs.Model;
using ApplicationT3.Service.DTOs.View;
using AutoMapper;

namespace ApplicationT3.Service.Mapper
{
    public class UserMappingProfile :Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserViewResponse>();

            CreateMap< UserModel, User>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}
