using Store.Application.DTOS.Attachment;
using Store.Application.DTOS.Brand;
using Store.Application.DTOS.Category;
using Store.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Product
{
    public class UpdateProductDto : BaseDto, IProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
