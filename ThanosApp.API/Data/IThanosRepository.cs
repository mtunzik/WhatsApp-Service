using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThanosApp.API.Models;
using ThanosApp.API.Helpers;

namespace ThanosApp.API.Data
{
    public interface IThanosRepository
    {
         void Add<T> (T entity) where T: class;
         void Delete<T> (T enity) where T: class;

         Task<bool> SaveAll();
         
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int Id);

         Task<Message> GetMessage(int id);

         Task<PagedList<Message>> GetMessagsForUser(MessageParams messageParam);
         
         Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);

        Task<IEnumerable<NavBar>> GetNavBar();
        Task<NavBar> GetNavBar(int id);

         
    }

    
}