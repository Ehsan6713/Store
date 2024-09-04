using AutoMapper;
using Moq;
using Shouldly;
using Store.Application.Contracts.Persistence;
using Store.Application.DTOS.Product;
using Store.Application.Features.Products.Handlers.Queries;
using Store.Application.Features.Products.Requests.Queries;
using Store.Application.Profiles;
using Store.Application.Resposes;
using Store.Application.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.UnitTests.Products.Queries
{
    public class GetProductDetailsRequestHandlerTest
    {
        IMapper mapper;
        Mock<IProductRepository> mockRepository;
        public GetProductDetailsRequestHandlerTest()
        {
            mockRepository=MockProductRepository.GetProductRepository();
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            mapper = mapperConfiguration.CreateMapper();
        }
        [Fact]
        public async Task GetProductDetailRequestTest()
        {
            var handler=new GetProductDetailRequestHandler(mockRepository.Object,mapper);
            var result=await handler.Handle(new GetProductDetailRequest(), CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<ProductDto>>();
        }
    }
}
