using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Api.Interfaces
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Insert(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(int id);
    }
}
