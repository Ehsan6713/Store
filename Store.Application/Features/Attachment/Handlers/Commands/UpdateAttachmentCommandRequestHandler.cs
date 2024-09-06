using AutoMapper;
using MediatR;
using Store.Application.DTOS.Attachment;
using Store.Application.DTOS.Attachment.Validations;
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
    public class UpdateAttachmentCommandRequestHandler : IRequestHandler<UpdateAttachmentCommandRequest, BaseResponse<Unit>>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public UpdateAttachmentCommandRequestHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(UpdateAttachmentCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            #region Validation
            var validator = new UpdateAttachmentDtoValidator();
            var validationResult = validator.Validate(request.UpdateAttachmentDto);
            if (validationResult.IsValid == false)
            {
                respons.Success = false;
                respons.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                respons.Message = "Error Occer";
            }
            #endregion
            else
            {
                var attachment = await attachmentRepository.Get(request.UpdateAttachmentDto.Id);
                mapper.Map(request.UpdateAttachmentDto, attachment);
                await attachmentRepository.Update(attachment);
                respons.Data = Unit.Value;
            }
            return respons;
        }
    }
}
