using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task Update(T entry);
        Task<bool> Exist(int id);
        Task<T> Add(T entry);
        Task Delete(T entry);


    }
}
