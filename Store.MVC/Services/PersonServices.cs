using AutoMapper;
using Store.MVC.Contracts;
using Store.MVC.Models.Brands;
using Store.MVC.Models.PersonViewModels;
using Store.MVC.Services;
using Store.MVC.Services.Base;

namespace Store.MVC.Services
{
    public class PersonServices : BaseHttpService, IPersonServices
    {
        private readonly IMapper mapper;

        public PersonServices(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(localStorageService, client)
        {
            this.mapper = mapper;
        }

        public async Task<Response<int>> Create(PersonVM record)
        {
            var response = new Response<int>();
            var PersonDto = mapper.Map<CreatePersonDto>(record);
            AddBearerToken();
            var responseApi = await client.PersonPOSTAsync(PersonDto);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            if (responseApi.Errors != null)
                foreach (var item in responseApi.Errors)
                {
                    response.ValidationErrors += item + Environment.NewLine;
                }
            return response;
        }

        public async Task<Response<int>> Delete(int id)
        {
            var response = new Response<int>();
            AddBearerToken();
            var responseApi = await client.PersonDELETEAsync(id);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            if (responseApi.Errors != null)
                foreach (var item in responseApi.Errors)
                {
                    response.ValidationErrors += item + Environment.NewLine;
                }
            return response;
        }

        public async Task<PersonVM> Get(int id)
        {
            AddBearerToken();
            var PersonDto = await client.PersonGETAsync(id);
            return mapper.Map<PersonVM>(PersonDto);
        }

        public async Task<List<PersonVM>> GetAll()
        {
            AddBearerToken();
            var lst = await client.PersonAllAsync();
            return mapper.Map<List<PersonVM>>(lst);
        }

        public async Task<Response<int>> Update(int id, PersonVM record)
        {
            var response = new Response<int>();
            var PersonDto = mapper.Map<UpdatePersonDto>(record);
            AddBearerToken();
            var responseApi = await client.PersonPUTAsync(id, PersonDto);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            if (responseApi.Errors != null)
                foreach (var item in responseApi.Errors)
                {
                    response.ValidationErrors += item + Environment.NewLine;
                }
            return response;
        }
    }
}
