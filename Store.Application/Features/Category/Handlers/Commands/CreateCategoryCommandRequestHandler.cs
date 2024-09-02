﻿using AutoMapper;
using MediatR;
using Store.Application.Features.Category.Requests.Commands;
using Store.Application.Persistence.Contracts;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Store.Application.Features.Category.Handlers.Commands
{
    public class CreateCategoryCommandRequestHandler : IRequestHandler<CreateCategoryCommandRequest, int>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandRequestHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Store.Domain.Category>(request.CreateCategoryDto);
            await categoryRepository.Add(category);
            return category.Id;
        }
    }
}