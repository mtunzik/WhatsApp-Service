using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThanosApp.API.Models;

namespace ThanosApp.API.Data
{
    public class AdminMenuRepository : IAdminMenuRepository
    {
         public readonly DataContext _context;
        public AdminMenuRepository (DataContext context) {
            _context = context;
        }
        public Task<bool> AdminMenuExist(AdminMenu adminMenu)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAdminMenu(AdminMenu adminMenu)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AdminMenu> GetAdminMenu(int id)
        {
           var AdminMenu = await _context.AdminMenus.Include(s => s.SubAdminMenu).FirstOrDefaultAsync(x => x.Id == id);
           return AdminMenu;
        }

        public async Task<IEnumerable<AdminMenu>> GetAdminMenus()
        {
            var AdminMenus = await _context.AdminMenus
            .Where(s => s.ParentId == null || s.ParentId == 0).Include(s => s.SubAdminMenu).ToListAsync();
            return AdminMenus;
        }

        public async Task<AdminMenu> SaveAdminMenu(AdminMenu adminMenu)
        {
             if (adminMenu.Id == 0 ) {
                adminMenu.UId = Guid.NewGuid ().ToString ();
                adminMenu.ParentUId = Guid.Empty.ToString ();
                adminMenu.IsDeleted = false;
                adminMenu.DateCreated = DateTime.Now;
                _context.AdminMenus.Add (adminMenu);
                await _context.SaveChangesAsync ();
                return adminMenu;

            } else {
                adminMenu.DateModified = DateTime.Now;
                _context.Entry (adminMenu).State = EntityState.Modified;
                try {
                   await _context.SaveChangesAsync ();
                   return adminMenu;
                } catch (DbUpdateConcurrencyException) {
                    // TODO:
                    return null;
                }
            }
           
        }
    }
}