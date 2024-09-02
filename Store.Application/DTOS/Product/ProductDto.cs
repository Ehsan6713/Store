using Store.Application.DTOS.Attachment;
using Store.Application.DTOS.Brand;
using Store.Application.DTOS.Category;
using Store.Application.DTOS.Common;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Product
{
    public class ProductDto : BaseDto
    {
        public uint Stock { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public BrandDto Brand { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public IList<AttachmentDto> Attachments { get; set; }
    }
}
