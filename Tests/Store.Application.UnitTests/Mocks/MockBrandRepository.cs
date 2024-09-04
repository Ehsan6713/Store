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
    public static class MockBrandRepository
    {
        public static Mock<IBrandRepository> GetBrandRepository()
        {
            var mockrepository = new Mock<IBrandRepository>();
            var brands = new List<Brand>() {
            new Brand(){CreateTime=DateTime.Now,Name="Samsung",Id=1},
            new Brand(){CreateTime=DateTime.Now,Name="Lg",Id=2},
            new Brand(){CreateTime=DateTime.Now,Name="Hp",Id=3},
            new Brand(){CreateTime=DateTime.Now,Name="Sony",Id=4}
            };
            mockrepository.Setup(x => x.GetAll()).ReturnsAsync(brands);

            mockrepository.Setup(x => x.Add(It.IsAny<Brand>())).Returns((Brand b) =>
            {
                brands.Add(b);
                return b;
            });
            mockrepository.Setup(x => x.Delete(It.IsAny<Brand>())).Callback((Brand b) =>
            {
                brands.Remove(b);
            });
            mockrepository.Setup(x => x.Get(It.IsAny<int>())).Returns((int x) =>
            {
                return brands.FirstOrDefault(t => t.Id == x);
            });

            return mockrepository;
        }
    }
}
