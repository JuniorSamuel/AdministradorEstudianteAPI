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
    public class ScoreRepository : IScoreRepository
    {
        private readonly ManagerStundetContext context;

        public ScoreRepository(ManagerStundetContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Student>> registerScore(List<Score> scores)
        {
            var addlist = scores.Where(c => c.Id == 0);
            var updatelist = scores.Where(c => c.Id != 0);

            context.Scores.UpdateRange(updatelist);
            await context.Scores.AddRangeAsync(addlist);
            await context.SaveChangesAsync();

            return await context.Students.Include(s => s.Scores).ToListAsync();
        }
    }
}
