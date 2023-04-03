using AutoMapper;
using ModsenTask.API.ViewModels;
using ModsenTask.Business.Models;

namespace ModsenTask.API.Mapper
{
    public class ApiToModelMapperProfile : Profile
    {
        public ApiToModelMapperProfile() 
        {
            CreateMap<BookModel, BookViewModel>()
               .ReverseMap();
            CreateMap<UserModel, UserViewModel>()
                .ReverseMap();
        }

    }
}
