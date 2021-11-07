using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBeep.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<ServiceResponse<IEnumerable<T>>> GetAll();
        public Task<ServiceResponse<T>> GetById(int? id);
        public Task<ServiceResponse<T>> Add(T unit);
        public ServiceResponse<T> Update(T unit);
        public ServiceResponse<T> Update(int id, T unit);
        public ServiceResponse<T> Delete(T unit);
        public ServiceResponse<T> DeleteById(int? id);
        public ServiceResponse<IQueryable<T>> FindDDL(Expression<Func<T, bool>> expression);
    }
}
