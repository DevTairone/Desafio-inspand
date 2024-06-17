using AutoMapper;
using Domain.Entities;
using WebApp.Models;

namespace WebApp.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateUserViewModel, User>();
            CreateMap<UpdateUserViewModel, User>();
        }
    }
}
