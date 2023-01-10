using ManagerStudent.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Core.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllWith(StudentInclude include);
    }
}
