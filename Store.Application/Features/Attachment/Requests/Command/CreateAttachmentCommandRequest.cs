using MediatR;
using Store.Application.DTOS.Attachment;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Requests.Command
{
    public class CreateAttachmentCommandRequest:IRequest<BaseResponse<int>>
    {
        public CreateAttachmentDto CreateAttachmentDto { get; set; }
    }
}
