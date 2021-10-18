using CRUDBlazorServer.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDBlazorServer.Data
{
    public class PublisherRepository : IRepository<Publisher>
    {
        protected AppContext _context;

        public PublisherRepository(AppContext context)
        {
            _context = context;
        }

        public async Task Add(Publisher entity)
        {
            await _context.Publishers.AddAsync(entity);
        }

        public async Task Delete(Publisher entity)
        {
            _context.Publishers.Remove(entity);
            await Save();
        }

        public async Task<IEnumerable<Publisher>> GetAll()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetById(int id)
        {
            return await _context.Publishers.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        Task IRepository<Publisher>.Update(Publisher entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
