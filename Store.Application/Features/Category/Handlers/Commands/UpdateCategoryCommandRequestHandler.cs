﻿using AutoMapper;
using MediatR;
using Store.Application.DTOS.Category.Validations;
using Store.Application.Features.Category.Requests.Commands;
using Store.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Category.Handlers.Commands
{
    public class UpdateCategoryCommandRequestHandler : IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public UpdateCategoryCommandRequestHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateCategoryDtoValidator();
            var validationResult = validator.Validate(request.UpdateCategoryDto);
            if (validationResult.IsValid == false)
                throw new Exception("Not Valid Object");
            #endregion
            var category =await categoryRepository.Get(request.UpdateCategoryDto.Id);
            mapper.Map(request.UpdateCategoryDto, category);
            await categoryRepository.Update(category);
            return Unit.Value;
        }
    }
}
