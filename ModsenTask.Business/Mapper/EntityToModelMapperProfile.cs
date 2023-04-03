using AutoMapper;
using ModsenTask.Business.Models;
using ModsenTask.Data.Entities;

namespace ModsenTask.Business.MapperProfiles
{
    public class EntityToModelMapperProfile : Profile
    {
        public EntityToModelMapperProfile() 
        {
            CreateMap<Book, BookModel>()
                .ReverseMap();

            CreateMap<User, UserModel>() 
                .ReverseMap();
        }
    }
}
