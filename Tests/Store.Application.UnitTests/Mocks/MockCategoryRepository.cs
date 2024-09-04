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
    public static class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var mockRepository=new Mock<ICategoryRepository>();
            var categories = new List<Category>()
            {
                new Category(){CreateTime=DateTime.Now,Name="Call Phone", Id = 1},
                new Category(){CreateTime=DateTime.Now,Name="Laptop",Id=2},
                new Category(){CreateTime=DateTime.Now,Name="All In One",Id=3}
            };

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(categories);

            mockRepository.Setup(x => x.Add(It.IsAny<Category>())).ReturnsAsync((Category c) => {
                categories.Add(c);
                return c;
            });

            mockRepository.Setup(x => x.Delete(It.IsAny<Category>())).Callback((Category c) =>
            {
                categories.Remove(c);

            });

            mockRepository.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return categories.FirstOrDefault(p => p.Id == id);
            });

            return mockRepository;
        }
    }
}
