using AutoMapper;
using MediatR;
using Store.Application.DTOS.Attachment.Validations;
using Store.Application.DTOS.Brand.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Attachment.Requests.Command;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Resposes;

namespace Store.Application.Features.Attachment.Handlers.Commands
{
    public class CreateAttachmentCommandRequestHandler : IRequestHandler<CreateAttachmentCommandRequest, BaseResponse<int>>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public CreateAttachmentCommandRequestHandler(IAttachmentRepository attachmentRepository,IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(CreateAttachmentCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<int>();
            #region Validation
            var validator = new CreateAttachmentDtoValidator();
            var validationResult = validator.Validate(request.CreateAttachmentDto);
            if (validationResult.IsValid == false)
            {
                respons.Success = false;
                respons.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                respons.Message = "Error Occer";
            }
            #endregion
            else
            {
                var attachment = mapper.Map<Domain.Attachment>(request.CreateAttachmentDto);
                await attachmentRepository.Add(attachment);
                respons.Data = attachment.Id;
            }
            return respons;
        }
    }
}
