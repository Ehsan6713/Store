using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOS.Attachment
{
    public interface IAttachmentDto
    {
        public string Title { get; set; }
        public byte[] Content { get; set; }
        public string Format { get; set; }
    }
}
