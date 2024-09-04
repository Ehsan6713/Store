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
    public class GetProductListRequestHandlerTest
    {
        IMapper mapper;
        Mock<IProductRepository> mockRepository;
        public GetProductListRequestHandlerTest()
        {
            mockRepository = MockProductRepository.GetProductRepository();
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task GetProductListRequestTest()
        {
            var handler = new GetProductListRequestHandler(mockRepository.Object, mapper);
            var result = await handler.Handle(new GetProductListRequest(), CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<List<ProductDto>>>();
            result.Data.Count().ShouldBeGreaterThan(1);
        }
    }
}
