using Store.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Product
{
    public class ChangeProductStockDto:BaseDto
    {
        public uint Stock { get; set; }
    }
}
