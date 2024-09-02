using Store.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Attachment
{
    public class CreateAttachmentDto: BaseDto
    {
        public string Title { get; set; }
        public byte[] Content { get; set; }
        public string Format { get; set; }
    }
}
