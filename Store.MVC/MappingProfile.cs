using AutoMapper;
using Store.MVC.Models.AttachmentViewModels;
using Store.MVC.Models.Brands;
using Store.MVC.Models.CategoryViewModels;
using Store.MVC.Models.OrderDetailViewModels;
using Store.MVC.Models.OrderViewModels;
using Store.MVC.Models.PersonViewModels;
using Store.MVC.Models.ProductViewModels;
using Store.MVC.Services.Base;

namespace Store.MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandDto, BrandVM>().ReverseMap();
            CreateMap<CreateBrandDto, BrandVM>().ReverseMap();
            CreateMap<UpdateBrandDto, BrandVM>().ReverseMap();

            CreateMap<CategoryVM, CategoryDto>().ReverseMap();
            CreateMap<CategoryVM, CreateCategoryDto>().ReverseMap();
            CreateMap<CategoryVM, UpdateCategoryDto>().ReverseMap();

            CreateMap<PersonVM, PersonDto>().ReverseMap();
            CreateMap<PersonVM, CreatePersonDto>().ReverseMap();
            CreateMap<PersonVM, UpdatePersonDto>().ReverseMap();

            CreateMap<ProductVM, ProductDto>().ReverseMap().ReverseMap();
            CreateMap<ProductVM, CreateProductDto>().ReverseMap();
            CreateMap<ProductVM, UpdateProductDto>().ReverseMap();

            CreateMap<AttachmentVM, AttachmentDto>().ReverseMap();
            CreateMap<AttachmentVM, CreateAttachmentDto>().ReverseMap();
            CreateMap<AttachmentVM, UpdateAttachmentDto>().ReverseMap();


            CreateMap<OrderVM, CreateOrderDto>().ReverseMap();
            CreateMap<OrderVM, OrderDto>().ReverseMap();
            CreateMap<OrderVM, UpdateOrderDto>().ReverseMap();


            CreateMap<OrderDetailVM, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetailVM, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetailVM, UpdateOrderDetailDto>().ReverseMap();
        }
    }
}
