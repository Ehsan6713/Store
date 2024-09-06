using Store.MVC.Models.Brands;
using Store.MVC.Services.Base;

namespace Store.MVC.Contracts
{
    public interface IDtoServices<T>where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<Response<int>> Create(T record);
        Task<Response<int>> Update(int id, T record);
        Task<Response<int>> Delete(int id);
    }
}
