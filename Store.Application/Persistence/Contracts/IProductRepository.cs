using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Persistence.Contracts
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task ChangeProductStock(Product product, uint stock);
    }
}
