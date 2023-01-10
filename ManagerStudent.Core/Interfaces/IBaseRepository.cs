using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T?> GetById(int id);
        Task<T> create(T obj);
        Task<T?> Delete(int id);
        Task<T> Update(T obj);
    }
}
