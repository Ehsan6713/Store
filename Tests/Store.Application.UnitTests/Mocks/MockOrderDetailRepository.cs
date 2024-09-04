using Moq;
using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.UnitTests.Mocks
{
    public static class MockOrderDetailRepository
    {
        public static Mock<IOrderDetailRepository> GetOrderDetailRepository()
        {
            var mock = new Mock<IOrderDetailRepository>();
            var lst = GetList();

            mock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return lst.FirstOrDefault(t => t.Id == id);
            });
            mock.Setup(x => x.Add(It.IsAny<OrderDetail>())).ReturnsAsync((OrderDetail record) =>
            {
                lst.Add(record);
                return record;
            });

            mock.Setup(x => x.Delete(It.IsAny<OrderDetail>())).Callback((OrderDetail record) =>
            {
                lst.Remove(record);
            });

            mock.Setup(x => x.GetAll()).ReturnsAsync(lst);

            return mock;
        }
        private static List<OrderDetail> GetList()
        {
            var lst = new List<OrderDetail>()
            {
                new OrderDetail(){Id=1, CreateTime=DateTime.Now, ProductId=1,Quantity=1,UnitPrice=50000},
                new OrderDetail(){Id=2, CreateTime=DateTime.Now, ProductId=3,Quantity=2,UnitPrice=50000},
                new OrderDetail(){Id=3, CreateTime=DateTime.Now, ProductId=4,Quantity=4,UnitPrice=200000},
                new OrderDetail(){Id=4, CreateTime=DateTime.Now, ProductId=2,Quantity=8,UnitPrice=400000},
            };
            return lst;
        }
    }
}
