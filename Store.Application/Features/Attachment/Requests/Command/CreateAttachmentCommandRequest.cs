using MediatR;
using Store.Application.DTOS.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Requests.Command
{
    public class CreateAttachmentCommandRequest:IRequest<int>
    {
        public CreateAttachmentDto CreateAttachmentDto { get; set; }
    }
}
