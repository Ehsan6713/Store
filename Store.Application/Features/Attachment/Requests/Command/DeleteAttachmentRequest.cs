using MediatR;
using Store.Application.Resposes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Requests.Command
{
    public class DeleteAttachmentRequest:IRequest<BaseResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
