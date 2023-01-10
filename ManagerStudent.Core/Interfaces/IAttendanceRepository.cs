using ManagerStudent.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Core.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAttendances();
        Task<IEnumerable<Attendance>> GetByDate(DateTime date);
        Task<List<Attendance?>> InsertAttendaces(List<Attendance> attendances);
    }
}
