using MediatR;
using Store.Application.DTOS.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Requests.Queries
{
    public class GetAttachmentDetailsRequst:IRequest<AttachmentDto>
    {
        public int Id { get; set; }
    }
}
