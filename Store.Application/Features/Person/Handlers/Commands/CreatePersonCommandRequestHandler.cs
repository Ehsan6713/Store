using AutoMapper;
using MediatR;
using Store.Application.DTOS.Person.Validations;
using Store.Application.DTOS.Product.Validations;
using Store.Application.Exceptions;
using Store.Application.Features.Person.Requests.Commands;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Resposes;

namespace Store.Application.Features.Person.Handlers.Commands
{
    public class CreatePersonCommandRequestHandler : IRequestHandler<CreatePersonCommandRequest, BaseResponse<int>>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public CreatePersonCommandRequestHandler(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<int>();
            #region Validation
            var validator = new CreatePersonDtoValidator();
            var validationResult = validator.Validate(request.CreatePersonDto);
            if (validationResult.IsValid == false)
            {
                respons.Success = false;
                respons.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                respons.Message = "Error Occer";
            }
            #endregion
            else
            {
                var person = mapper.Map<Domain.Person>(request.CreatePersonDto);
                await personRepository.Add(person);
                respons.Data = person.Id;
            }
            return respons;
        }
    }
}
