using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
        public async override Task<IReadOnlyList<Product>> GetAll()
        {
            return await storeDbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
        }
        public async override Task<Product> Get(int id)
        {
            return await storeDbContext.Products.Where(x => x.Id == id)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync();
        }
        public async Task ChangeProductStock(Product product, uint stock)
        {
            product.Stock = stock;
            storeDbContext.Entry(product).State = EntityState.Modified;
            await storeDbContext.SaveChangesAsync();

        }
    }
}
