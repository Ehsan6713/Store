using AutoMapper;
using Store.MVC.Contracts;
using Store.MVC.Models.Brands;
using Store.MVC.Models.ProductViewModels;
using Store.MVC.Services.Base;

namespace Store.MVC.Services
{
    public class ProductServices : BaseHttpService, IProductServices
    {
        private readonly IMapper mapper;

        public ProductServices(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(localStorageService, client)
        {
            this.mapper = mapper;
        }

        public async Task<Response<int>> Create(ProductVM record)
        {
            var response = new Response<int>();
            var ProductDto = mapper.Map<CreateProductDto>(record);
            AddBearerToken();
            var responseApi = await client.ProductPOSTAsync(ProductDto);
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
            var responseApi = await client.ProductDELETEAsync(id);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            if (responseApi.Errors != null)
                foreach (var item in responseApi.Errors)
                {
                    response.ValidationErrors += item + Environment.NewLine;
                }
            return response;
        }

        public async Task<ProductVM> Get(int id)
        {
            AddBearerToken();
            var ProductDto = await client.ProductGET2Async(id);
            return mapper.Map<ProductVM>(ProductDto.Data);
        }

        public async Task<List<ProductVM>> GetAll()
        {
            AddBearerToken();
            var lst = await client.ProductGETAsync();
            return mapper.Map<List<ProductVM>>(lst.Data);
        }

        public async Task<Response<int>> Update(int id, ProductVM record)
        {
            var response = new Response<int>();
            var ProductDto = mapper.Map<UpdateProductDto>(record);
            AddBearerToken();
            var responseApi = await client.ProductPUTAsync(id, ProductDto);
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
