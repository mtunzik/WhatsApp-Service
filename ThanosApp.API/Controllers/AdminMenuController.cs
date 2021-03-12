using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThanosApp.API.Data;
using ThanosApp.API.Models;

namespace ThanosApp.API.Controllers {

    [Authorize]
    [ApiController]
    [Route ("api/[controller]")]
    public class AdminMenuController : ControllerBase {
        public readonly IAdminMenuRepository _repo;

        public AdminMenuController (IAdminMenuRepository repo) {
            _repo = repo;
        }

        //Get AdminMenus
        [HttpGet]
        public async Task<IActionResult> GetAdminMenus () {
            var adminMenus = await _repo.GetAdminMenus ();
            return Ok (adminMenus);
        }

        //Get AdminMenu by Id
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetAdminMenu (int id) {
            var adminMenu = await _repo.GetAdminMenu (id);
            return Ok (adminMenu);
        }

        //Post AdminMenu
        [HttpPost]
        public async Task<IActionResult> SaveAdminMenu (AdminMenu adminMenu) {
            if (!ModelState.IsValid) {
                 var smenu = await _repo.SaveAdminMenu (adminMenu);
                return Ok(smenu);
            } else {
                return BadRequest (ModelState);
            }

        }

    }
}