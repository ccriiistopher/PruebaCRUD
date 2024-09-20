using AutoMapper;
using PruebaCRUD.Dto;
using PruebaCRUD.Models;

namespace PruebaCRUD.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<User, PostUserDto>();
            CreateMap<PostUserDto, User>();
            CreateMap<PutUserDto, User>();
            CreateMap<User, PutUserDto>();
        }
    }
}
