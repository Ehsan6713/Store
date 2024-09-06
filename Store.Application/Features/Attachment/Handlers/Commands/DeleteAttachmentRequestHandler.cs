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
using Store.Application.Resposes;

namespace Store.Application.Features.Attachment.Handlers.Commands
{
    public class DeleteAttachmentRequestHandler : IRequestHandler<DeleteAttachmentRequest, BaseResponse<Unit>>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public DeleteAttachmentRequestHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(DeleteAttachmentRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            var attachment = await attachmentRepository.Get(request.Id);
            if (attachment == null)
            {
                respons.Success = false;
                respons.Errors.Add($"Not Found Id {request.Id}");
                respons.Message = $"Not Found {request.Id}";
            }
            else
            {
                await attachmentRepository.Delete(attachment);
                respons.Data = Unit.Value;
            }
            return respons;
        }
    }
}
