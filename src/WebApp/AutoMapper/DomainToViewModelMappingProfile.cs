using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApp.Models;
using AutoMapper;

namespace WebApp.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, CreateUserViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, UpdateUserViewModel>();

        }
    }
}
