using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repositories
{
    public class OrderRepository:GenericRepository<Domain.Order>, IOrderRepository
    {
        private readonly StoreDbContext storeDbContext;

        public OrderRepository(StoreDbContext storeDbContext):base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
    }
}
