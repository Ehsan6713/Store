using AutoMapper;
using MediatR;
using Store.Application.DTOS.Person.Validations;
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
    public class UpdatePersonCommandRequestHandler : IRequestHandler<UpdatePersonCommandRequest, BaseResponse<Unit>>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public UpdatePersonCommandRequestHandler(IPersonRepository personRepository,IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponse<Unit>> Handle(UpdatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var respons = new BaseResponse<Unit>();
            #region Validation
            var validator = new UpdatePersonDtoValidator();
            var validationResult = validator.Validate(request.UpdatePersonDto);
            if (validationResult.IsValid == false)
            {
                respons.Success = false;
                respons.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                respons.Message = "Error Occer";
            }
            #endregion
            else
            {
                var person = await personRepository.Get(request.UpdatePersonDto.Id);
                mapper.Map(request.UpdatePersonDto, person);
                await personRepository.Update(person);
                respons.Data = Unit.Value;
            }
            return respons;
        }
    }
}
