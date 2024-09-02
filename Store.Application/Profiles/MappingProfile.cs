using AutoMapper;
using Store.Application.DTOS.Attachment;
using Store.Application.DTOS.Brand;
using Store.Application.DTOS.Category;
using Store.Application.DTOS.Order;
using Store.Application.DTOS.OrderDetail;
using Store.Application.DTOS.Person;
using Store.Application.DTOS.Product;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, CreatePersonDto>().ReverseMap();
            CreateMap<Person, UpdatePersonDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ChangeProductStockDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Attachment, AttachmentDto>().ReverseMap();
            CreateMap<Attachment, CreateAttachmentDto>().ReverseMap();
            CreateMap<Attachment, UpdateAttachmentDto>().ReverseMap();


            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();


            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
        }
    }
}
