using ManagerStudent.Core.Entities;
using ManagerStudent.Core.Interfaces;
using ManagerStudent.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Infrastructure.Repository
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ManagerStundetContext _context) 
            : base(_context)
        {

        }
    }
}
