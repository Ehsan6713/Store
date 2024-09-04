using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repositories
{
    public class PersonRepository:GenericRepository<Person>, IPersonRepository
    {
        private readonly StoreDbContext storeDbContext;

        public PersonRepository(StoreDbContext storeDbContext):base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
    }
}
