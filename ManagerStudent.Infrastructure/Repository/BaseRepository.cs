using ManagerStudent.Core.Interfaces;
using ManagerStudent.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ManagerStundetContext context;

        public BaseRepository(ManagerStundetContext _context)
        {
            context = _context;
        }

        public async Task<T> create(T obj)
        {
            context.Add<T>(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<T?> Delete(int id)
        {
            var obj = await context.FindAsync<T>(id);

            if (obj is null)
                return null;

            context.Remove(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<T>> Get()
        {
           return await context.Set<T>()
                 .ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await context.FindAsync<T>(id);
        }

        public async Task<T> Update(T obj)
        {
            context.Update<T>(obj);
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
