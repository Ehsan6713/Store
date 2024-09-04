using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly StoreDbContext storeDbContext;

        public ProductRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task ChangeProductStock(Product product, uint stock)
        {
            product.Stock = stock;
            storeDbContext.Entry(product).State = EntityState.Modified;
            await storeDbContext.SaveChangesAsync();

        }
    }
}
