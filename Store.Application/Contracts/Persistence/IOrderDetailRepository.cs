using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Persistence
{
    public interface IOrderDetailRepository:IGenericRepository<OrderDetail>
    {
    }
}
