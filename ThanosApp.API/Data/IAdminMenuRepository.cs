using System.Collections.Generic;
using System.Threading.Tasks;
using ThanosApp.API.Models;

namespace ThanosApp.API.Data
{
    public interface IAdminMenuRepository
    {
        Task<IEnumerable<AdminMenu>> GetAdminMenus();
         Task<AdminMenu> SaveAdminMenu (AdminMenu adminMenu);

         Task<AdminMenu> GetAdminMenu(int id); 

         Task<bool> AdminMenuExist(AdminMenu adminMenu);

         Task<bool> DeleteAdminMenu(AdminMenu adminMenu);

    }
}