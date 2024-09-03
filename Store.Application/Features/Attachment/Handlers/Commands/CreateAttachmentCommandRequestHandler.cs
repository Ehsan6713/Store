﻿using AutoMapper;
using MediatR;
using Store.Application.DTOS.Attachment.Validations;
using Store.Application.DTOS.Brand.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Attachment.Requests.Command;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Handlers.Commands
{
    public class CreateAttachmentCommandRequestHandler : IRequestHandler<CreateAttachmentCommandRequest, int>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public CreateAttachmentCommandRequestHandler(IAttachmentRepository attachmentRepository,IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateAttachmentCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateAttachmentDtoValidator();
            var validationResult = validator.Validate(request.CreateAttachmentDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion
            var attachment = mapper.Map<Domain.Attachment>(request.CreateAttachmentDto);
            await attachmentRepository.Add(attachment);
            return attachment.Id;
        }
    }
}
