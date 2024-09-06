using AutoMapper;
using Store.MVC.Contracts;
using Store.MVC.Models.AttachmentViewModels;
using Store.MVC.Services.Base;

namespace Store.MVC.Services
{
    public class AttachmentServices : BaseHttpService, IAttachmentServices
    {
        private readonly IMapper mapper;

        public AttachmentServices(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(localStorageService, client)
        {
            this.mapper = mapper;
        }

        public async Task<Response<int>> Create(AttachmentVM record)
        {
            var response = new Response<int>();
            var AttachmentDto = mapper.Map<CreateAttachmentDto>(record);
            AddBearerToken();
            var responseApi = await client.AttachmentPOSTAsync(AttachmentDto);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
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
            var responseApi = await client.AttachmentDELETEAsync(id);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            if (responseApi.Errors != null)
                foreach (var item in responseApi.Errors)
            {
                response.ValidationErrors += item + Environment.NewLine;
            }
            return response;
        }

        public async Task<AttachmentVM> Get(int id)
        {
            AddBearerToken();
            var AttachmentDto = await client.AttachmentGETAsync(id);
            return mapper.Map<AttachmentVM>(AttachmentDto);
        }

        public async Task<List<AttachmentVM>> GetAll()
        {
            AddBearerToken();
            var lst = await client.AttachmentAllAsync();
            return mapper.Map<List<AttachmentVM>>(lst);
        }

        public async Task<Response<int>> Update(int id, AttachmentVM record)
        {
            var response = new Response<int>();
            var AttachmentDto = mapper.Map<UpdateAttachmentDto>(record);
            AddBearerToken();
            var responseApi = await client.AttachmentPUTAsync(id, AttachmentDto);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            foreach (var item in responseApi.Errors)
            {
                response.ValidationErrors += item + Environment.NewLine;
            }
            return response;
        }
    }
}
