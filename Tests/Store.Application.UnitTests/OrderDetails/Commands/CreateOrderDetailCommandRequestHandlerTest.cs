using AutoMapper;
using Moq;
using Shouldly;
using Store.Application.Contracts.Persistence;
using Store.Application.DTOS.OrderDetail;
using Store.Application.Features.OrderDetail.Handlers.Commands;
using Store.Application.Features.OrderDetail.Requests.Commands;
using Store.Application.Profiles;
using Store.Application.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.UnitTests.OrderDetails.Commands
{
    public class CreateOrderDetailCommandRequestHandlerTest
    {
        IMapper mapper;
        Mock<IOrderDetailRepository> mockRepository;
        Mock<IProductRepository> mockRepositoryProduct;
        CreateOrderDetailDto createOrderDetailDto;
        public CreateOrderDetailCommandRequestHandlerTest()
        {
            mockRepository = MockOrderDetailRepository.GetOrderDetailRepository();
            mockRepositoryProduct = MockProductRepository.GetProductRepository();
            var mapperConfiguration = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
            mapper = mapperConfiguration.CreateMapper();
            createOrderDetailDto=new CreateOrderDetailDto() { ProductId = 8,Quantity=10,UnitPrice=546545,OrderId=1,Discount=1 };
        }
        [Fact]
        public async Task CreateOrderDetailCommandRequest_CreateOrderByZeroStock_DoNotSave()
        {
            try
            {
                var handler = new CreateOrderDetailCommandRequestHandler(mockRepository.Object, mapper, mockRepositoryProduct.Object);
                var result = await handler.Handle(new CreateOrderDetailCommandRequest() { CreateOrderDetailDto = createOrderDetailDto }, CancellationToken.None);
            }
            catch(Exception ex)
            {

            }
            var addedRecord= mockRepository.Object.GetAll().Result.Where(x => x.Id == 0).Any();
            Assert.True(!addedRecord);

        }
    }
}
