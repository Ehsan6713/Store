﻿using AutoMapper;
using MediatR;
using Store.Application.DTOS.Attachment;
using Store.Application.Features.Attachment.Requests.Command;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Attachment.Handlers.Commands
{
    public class UpdateAttachmentCommandRequestHandler : IRequestHandler<UpdateAttachmentCommandRequest, Unit>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public UpdateAttachmentCommandRequestHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAttachmentCommandRequest request, CancellationToken cancellationToken)
        {
            var attachment = await attachmentRepository.Get(request.AttachmentDto.Id);
            mapper.Map(request.AttachmentDto, attachment);
            await attachmentRepository.Update(attachment);
            return Unit.Value;
        }
    }
}