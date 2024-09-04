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
    public static class MockPersonRepository
    {
        public static Mock<IPersonRepository> GetPersonRepository()
        {
            var mock = new Mock<IPersonRepository>();
            var lst = GetList();

            mock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return lst.FirstOrDefault(t => t.Id == id);
            });
            mock.Setup(x => x.Add(It.IsAny<Person>())).ReturnsAsync((Person record) =>
            {
                lst.Add(record);
                return record;
            });

            mock.Setup(x => x.Delete(It.IsAny<Person>())).Callback((Person record) =>
            {
                lst.Remove(record);
            });
            mock.Setup(x => x.Exist(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return lst.Any(x => x.Id == id);
            });
            mock.Setup(x => x.GetAll()).ReturnsAsync(lst);

            return mock;
        }
        private static List<Person> GetList()
        {
            var lst = new List<Person>()
            {
                new Person(){ CreateTime=DateTime.Now,Id=1,FirstName="Ali",LastName="Ahmadi",Gender=1},
                new Person(){ CreateTime=DateTime.Now,Id=2,FirstName="Javad",LastName="Sagheb",Gender=1},
                new Person(){ CreateTime=DateTime.Now,Id=3,FirstName="Vania",LastName="sagheb",Gender=0},
                new Person(){ CreateTime=DateTime.Now,Id=4,FirstName="zahra",LastName="Hekmati",Gender=0},
                new Person(){ CreateTime=DateTime.Now,Id=5,FirstName="Mahdi",LastName="zare",Gender=1}
            };
            return lst;
        }
    }
}
