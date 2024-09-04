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
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var mock = new Mock<IProductRepository>();
            var lst = GetList();

            mock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return lst.FirstOrDefault(t => t.Id == id);
            });
            mock.Setup(x => x.Add(It.IsAny<Product>())).ReturnsAsync((Product record) =>
            {
                lst.Add(record);
                return record;
            });

            mock.Setup(x => x.Delete(It.IsAny<Product>())).Callback((Product record) =>
            {
                lst.Remove(record);
            });

            mock.Setup(x => x.GetAll()).ReturnsAsync(lst);

            return mock;
        }
        private static List<Product> GetList()
        {
            var lst = new List<Product>()
            {
                new Product(){ CreateTime=DateTime.Now,Title="S24",Description="A Good Cell Phone Of Samsung",BrandId=1,CategoryId=1,Stock=100,Id=1},
                new Product(){ CreateTime=DateTime.Now,Title="S23",Description="A Good Cell Phone Of Samsung",BrandId=1,CategoryId=1,Stock=20,Id=2},
                new Product(){ CreateTime=DateTime.Now,Title="S22",Description="A Good Cell Phone Of Samsung",BrandId=1,CategoryId=1,Stock=15,Id=3},
                new Product(){ CreateTime=DateTime.Now,Title="S21",Description="A Good Cell Phone Of Samsung",BrandId=1,CategoryId=1,Stock=5,Id=4},
                new Product(){ CreateTime=DateTime.Now,Title="Pavilio15",Description="A Labtop  Of Hp",BrandId=3,CategoryId=2,Stock=65,Id=5},
                new Product(){ CreateTime=DateTime.Now,Title="Pavilio10",Description="A Labtop  Of Hp",BrandId=3,CategoryId=2,Stock=45,Id=6},
                new Product(){ CreateTime=DateTime.Now,Title="Pavilio5",Description="A Labtop  Of Hp",BrandId=3,CategoryId=2,Stock=45,Id=7},
            };
            return lst;
        }
    }
}
