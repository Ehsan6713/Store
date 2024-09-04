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
    public static class MockOrderRepository
    {
        public static Mock<IOrderRepository> GetOrderRepository()
        {
            var mock = new Mock<IOrderRepository>();
            var lst = GetList();

            mock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return lst.FirstOrDefault(t => t.Id == id);
            });
            mock.Setup(x => x.Add(It.IsAny<Order>())).ReturnsAsync((Order record) =>
            {
                lst.Add(record);
                return record;
            });

            mock.Setup(x => x.Delete(It.IsAny<Order>())).Callback((Order record) =>
            {
                lst.Remove(record);
            });

            mock.Setup(x => x.GetAll()).ReturnsAsync(lst);

            return mock;
        }
        private static List<Order> GetList()
        {
            var lst = new List<Order>()
            {
                new Order(){Id=1, CreateTime=DateTime.Now,UserId=1,Total=100000},
                new Order(){Id=2, CreateTime=DateTime.Now,UserId=2,Total=200000},
                new Order(){Id=3, CreateTime=DateTime.Now,UserId=3,Total=400000},
            };
            return lst;
        }
    }
}
