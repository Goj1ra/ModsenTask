using AutoMapper;
using ModsenTask.Business.MapperProfiles;

namespace ModsenTask.Business.Mapper
{
    public class ApplicationMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<EntityToModelMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper = Lazy.Value;
    }
}
