using AutoMapper;
using MediatR;
using Store.Application.DTOS.Attachment;
using Store.Application.Features.Attachment.Requests.Queries;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Handlers.Queries
{
    public class GetAttachmentListRequestHandler : IRequestHandler<GetAttachmentListRequest, List<AttachmentDto>>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public GetAttachmentListRequestHandler(IAttachmentRepository attachmentRepository,IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<List<AttachmentDto>> Handle(GetAttachmentListRequest request, CancellationToken cancellationToken)
        {
            var attachments =await attachmentRepository.GetAll();
            return mapper.Map<List<AttachmentDto>>(attachments);
        }
    }
}
