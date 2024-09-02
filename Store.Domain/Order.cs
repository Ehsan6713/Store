using Store.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Order:BaseDomainEntity
    {
        public int UserId { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
