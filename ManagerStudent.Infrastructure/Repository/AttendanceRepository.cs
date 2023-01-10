using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerStudent.Core.Entities;
using ManagerStudent.Core.Interfaces;
using ManagerStudent.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ManagerStudent.Infrastructure.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ManagerStundetContext context;

        public AttendanceRepository(ManagerStundetContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Attendance>> GetByDate(DateTime date)
        {
            var attendances = await context.Attendances.Where(a => a.Date == date).ToListAsync();
            return attendances;
        }

        public async Task<IEnumerable<Attendance>> GetAttendances()
        {
            return await context.Attendances.ToListAsync();
        }

        public async Task<List<Attendance?>> InsertAttendaces(List<Attendance> attendances)
        {
            var saveAttendance = new List<Attendance>();

           attendances.ForEach( element =>
            {
               var Has = context.Attendances.Any(a => a.StudentId == element.StudentId && a.Date == element.Date);

                if (!Has)
                    saveAttendance.Add(element);
            });

            try
            {
                await context.Attendances.AddRangeAsync(saveAttendance);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return saveAttendance;
        }
    }
}
