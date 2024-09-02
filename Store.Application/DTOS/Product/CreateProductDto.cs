using Store.Application.DTOS.Attachment;
using Store.Application.DTOS.Brand;
using Store.Application.DTOS.Category;
using Store.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Product
{
    public class CreateProductDto : BaseDto
    {
        public string Title { get; set; }
        public uint Stock { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public IList<AttachmentDto> Attachments { get; set; }
    }
}
