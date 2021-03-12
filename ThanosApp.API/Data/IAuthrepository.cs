using System.Threading.Tasks;
using ThanosApp.API.Models;

namespace ThanosApp.API.Data
{
    public interface IAuthrepository
    {
         Task<User> Register(User user, string password);

         Task<User> Login(string username, string password);

         Task<bool> UserExist(string username);
    }
}