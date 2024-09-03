using Store.Application.DTOS.Common;
using Store.Application.DTOS.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.OrderDetail
{
    public class CreateOrderDetailDto 
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
