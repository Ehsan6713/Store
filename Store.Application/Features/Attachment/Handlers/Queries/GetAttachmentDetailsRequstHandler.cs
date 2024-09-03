using AutoMapper;
using MediatR;
using Store.Application.DTOS.Attachment;
using Store.Application.Features.Attachment.Requests.Queries;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Handlers.Queries
{
    public class GetAttachmentDetailsRequstHandler : IRequestHandler<GetAttachmentDetailsRequst, AttachmentDto>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public GetAttachmentDetailsRequstHandler(IAttachmentRepository attachmentRepository,IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<AttachmentDto> Handle(GetAttachmentDetailsRequst request, CancellationToken cancellationToken)
        {
            var attachment = await attachmentRepository.Get(request.Id);
            return mapper.Map<AttachmentDto>(attachment);
        }
    }
}
