using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StoreDbContext contex;

        public GenericRepository(StoreDbContext storeDbContext)
        {
            contex = storeDbContext;
        }
        public virtual async Task<T> Add(T entry)
        {
            await contex.AddAsync(entry);
            await contex.SaveChangesAsync();
            return entry;
        }

        public virtual async Task Delete(T entry)
        {
            contex.Set<T>().Remove(entry);
            await contex.SaveChangesAsync();
        }

        public virtual async Task<bool> Exist(int id)
        {
            var entity = Get(id);
            return entity != null;
        }

        public virtual async Task<T> Get(int id)
        {
            return await contex.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAll()
        {
            return await contex.Set<T>().ToListAsync();
        }

        public virtual async Task Update(T entry)
        {
            contex.Entry(entry).State = EntityState.Modified;
            await contex.SaveChangesAsync();
        }
    }
}
