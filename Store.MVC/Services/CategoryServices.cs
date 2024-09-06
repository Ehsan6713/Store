using AutoMapper;
using Store.MVC.Contracts;
using Store.MVC.Models.Brands;
using Store.MVC.Models.CategoryViewModels;
using Store.MVC.Services.Base;

namespace Store.MVC.Services
{
    public class CategoryServices : BaseHttpService, ICategoryServices
    {
        private readonly IMapper mapper;

        public CategoryServices(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(localStorageService, client)
        {
            this.mapper = mapper;
        }

        public async Task<Response<int>> Create(CategoryVM record)
        {
            var response = new Response<int>();
            var categoryDto = mapper.Map<CreateCategoryDto>(record);
            AddBearerToken();
            var responseApi = await client.CategoryPOSTAsync(categoryDto);
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
            var responseApi = await client.CategoryDELETEAsync(id);
            response.Message = responseApi.Message;
            response.Success = responseApi.Success;
            if (responseApi.Errors != null)
                foreach (var item in responseApi.Errors)
            {
                response.ValidationErrors += item + Environment.NewLine;
            }
            return response;
        }

        public async Task<CategoryVM> Get(int id)
        {
            AddBearerToken();
            var categoryDto = await client.CategoryGETAsync(id);
            return mapper.Map<CategoryVM>(categoryDto);
        }

        public async Task<List<CategoryVM>> GetAll()
        {
            AddBearerToken();
            var lst = await client.CategoryAllAsync();
            return mapper.Map<List<CategoryVM>>(lst);
        }

        public async Task<Response<int>> Update(int id, CategoryVM record)
        {
            var response = new Response<int>();
            var categoryDto = mapper.Map<UpdateCategoryDto>(record);
            AddBearerToken();
            var responseApi = await client.CategoryPUTAsync(id, categoryDto);
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
