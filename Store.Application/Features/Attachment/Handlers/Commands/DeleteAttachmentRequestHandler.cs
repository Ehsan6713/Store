using AutoMapper;
using MediatR;
using Store.Application.Exceptions;
using Store.Application.Features.Attachment.Requests.Command;
using Store.Application.Contracts.Persistence;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Handlers.Commands
{
    public class DeleteAttachmentRequestHandler : IRequestHandler<DeleteAttachmentRequest>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public DeleteAttachmentRequestHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task Handle(DeleteAttachmentRequest request, CancellationToken cancellationToken)
        {
            var attachment = await attachmentRepository.Get(request.Id);
            if (attachment == null)
            {
                throw new NotFoundException(nameof(Domain.Attachment), request.Id);
            }
            await attachmentRepository.Delete(attachment);
        }
    }
}
