using AutoMapper;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name));
            CreateMap<Category, CategoryViewModel>()
                .ReverseMap();
            CreateMap<Receipt, ReceiptViewModel>()
               .ReverseMap();
            CreateMap<Tag, TagViewModel>()
               .ReverseMap();
            CreateMap<Comment, CommentViewModel>()
               .ReverseMap();

            ///


            CreateMap<ProductViewModel, Product>();


        }
    }
}