using CRUDBlazorServer.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBlazorServer.Data
{
    public class Dndbookrepository : IRepository<Dndbook>
    {
        protected AppContext _context;

        public Dndbookrepository(AppContext context)
        {
            _context = context;
        }

        public async Task Add(Dndbook entity)
        {
            await _context.Dndbooks.AddAsync(entity);
            await Save();
        }

        public async Task Delete(Dndbook entity)
        {
            _context.Dndbooks.Remove(entity);
            await Save();
        }

        public async Task<IEnumerable<Dndbook>> GetAll()
        {
            return await _context.Dndbooks.Include(x => x.Publisher)
                                          .ToListAsync();

        }

        public async Task<Dndbook> GetById(int id)
        {
            return await _context.Dndbooks.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dndbook>> GetByPublisher(Publisher publisher)
        {
            return await _context.Dndbooks.Include(x => x.Publisher)
                                          .Where(x => x.Publisher == publisher)
                                          .ToListAsync();
        }

        public async Task Update(Dndbook entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }
    }
}
