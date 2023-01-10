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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly ManagerStundetContext context;

        public StudentRepository(ManagerStundetContext _context) 
            : base(_context)
        {
            context = _context;
        }


        public async Task<IEnumerable<Student>> GetAllWith(StudentInclude include)
        {
            switch (include)
            {
                case StudentInclude.Score:
                    return await context.Students.Include( s => s.Scores).ToListAsync();
                case StudentInclude.Attendance:
                    return await context.Students.Include(s => s.Attendances).ToListAsync();
            }

            return await context.Students.Include(s => s.Scores).Include( s => s.Attendances).ToListAsync();
        }
    }
}
