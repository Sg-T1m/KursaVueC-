using AutoMapper;
using KursaVue.Model;

namespace KursaVue.Mapping
{
    public class AppMappingProduct : Profile
    {
        public AppMappingProduct()
        {
            CreateMap<Product, Category>().ReverseMap();
        }
    }
}
