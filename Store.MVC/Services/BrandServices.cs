using AutoMapper;
using Hanssens.Net;
using Store.MVC.Contracts;
using Store.MVC.Models.Brands;
using Store.MVC.Services.Base;

namespace Store.MVC.Services
{
    public class BrandServices : BaseHttpService, IBrandServices
    {
        private readonly IClient clientHttp;
        private readonly ILocalStorageService localStorage2;
        private readonly IMapper mapper;

        //private readonly IClient httpclient;

        public BrandServices(IClient clientHttp, ILocalStorageService localStorage2, IMapper mapper) : base(localStorage2, clientHttp)
        {
            this.clientHttp = clientHttp;
            this.localStorage2 = localStorage2;
            this.mapper = mapper;
        }
        public async Task<Response<int>> Create(BrandVM brand)
        {
            var response = new Response<int>();
            var brandDto = mapper.Map<CreateBrandDto>(brand);
            AddBearerToken();
            var apiResponse = await client.BrandPOSTAsync(brandDto);
            if (apiResponse.Success)
            {
                response.Data = apiResponse.Data;
                response.Success = true;
            }
            else
            {
                response.Success = false;

                foreach (var item in apiResponse.Errors)
                {
                    response.ValidationErrors += item + Environment.NewLine;
                }
            }
            return response;
        }

        public async Task<Response<int>> Delete(int id)
        {
            var response = new Response<int>();
            AddBearerToken();
            var apiResponse = await client.BrandDELETEAsync(id);
            response.Success = apiResponse.Success;
            response.Message = "Successfully Delete";
            if (apiResponse.Errors != null)
                foreach (var item in apiResponse.Errors)
                {
                    response.ValidationErrors += item + Environment.NewLine;
                }
            return response;
        }

        public async Task<BrandVM> Get(int id)
        {
            AddBearerToken();
            var branddto = await client.BrandGETAsync(id, CancellationToken.None);
            return mapper.Map<BrandVM>(branddto);
        }

        public async Task<List<BrandVM>> GetAll()
        {
            AddBearerToken();
            var branddtos = await client.BrandAllAsync();
            return mapper.Map<List<BrandVM>>(branddtos);
        }

        public async Task<Response<int>> Update(int id, BrandVM brand)
        {
            var response = new Response<int>();
            var updatebrandDto = mapper.Map<UpdateBrandDto>(brand);
            AddBearerToken();
            var responseApi = await client.BrandPUTAsync(id, updatebrandDto);
            response.Success = responseApi.Success;
            response.Message = responseApi.Message;
            response.Data = brand.Id;
            return response;
        }
    }
}
