using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Domain.Responses;

namespace WebApplication2.Domain.Services
{
    public interface IGenericService<T> where T:class
    {
        Task<BaseResponse<T>> GetById(int id);

        Task<BaseResponse<IEnumerable<T>>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountWhere(Expression<Func<T, bool>> predicate);

        Task<BaseResponse<T>> Add(T entry);

        Task<BaseResponse<T>> update(T entry);
        Task<BaseResponse<T>> Delete(int id);

    }
}
