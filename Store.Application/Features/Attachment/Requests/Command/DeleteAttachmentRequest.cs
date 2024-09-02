using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Requests.Command
{
    public class DeleteAttachmentRequest:IRequest
    {
        public int Id { get; set; }
    }
}
