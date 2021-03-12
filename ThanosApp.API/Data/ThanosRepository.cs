using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThanosApp.API.Helpers;
using ThanosApp.API.Models;

namespace ThanosApp.API.Data
{
    public class ThanosRepository : IThanosRepository
    {
        private readonly DataContext _context;

        public ThanosRepository(DataContext context)
        {
            _context = context ;
        }
        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity );
        }

        public void Delete<T>(T enity) where T : class
        {
            _context.Remove(enity);
        }

        public async  Task<Message> GetMessage(int id)
        {
           return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedList<Message>> GetMessagsForUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedList<Message>> GetMessagsForUser(MessageParams messageParam)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<NavBar>> GetNavBar()
        {
            var navbar = await _context.NavBar.Include(x => x.SubIcon)
                .Include(p => p.SubImage).ToListAsync();
            return  navbar;
        }

        public async Task<NavBar> GetNavBar(int Id)
        {
           var navbar = await _context.NavBar.Include(p => p.SubImage)
                .Include(i => i.SubIcon).FirstOrDefaultAsync(x => x.Id == Id);
           return navbar ;
        }

        public async  Task<User> GetUser(int Id)
        {
           var user = await _context.Users.Include(p => p.Photos ).Include(g => g.Gender ).FirstOrDefaultAsync(u => u.Id == Id);
           return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async  Task<bool> SaveAll()
        {
          return await _context.SaveChangesAsync() > 0;
        }
    }
}