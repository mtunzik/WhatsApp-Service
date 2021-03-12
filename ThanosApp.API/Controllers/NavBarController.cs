
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThanosApp.API.Data;
using ThanosApp.API.Dtos;
using ThanosApp.API.Models;

namespace ThanosApp.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NavBarController : ControllerBase
    {
        private readonly IThanosRepository _repo;
         
         public NavBarController(IThanosRepository repo)
         {
             _repo = repo;
         }
        
        [HttpGet]
        [Route("navbar")]
        public async Task<IActionResult> GetNavBar(){
            var navFromRepo = await _repo.GetNavBar();
            return Ok(navFromRepo) ;

        }
        [HttpGet]
        [Route("navbar/:id")]
        public async Task<IActionResult> GetNavBar(int id){
            var navFromRepo = await _repo.GetNavBar(id);
            return Ok(navFromRepo) ;

        }


        [HttpPost]
        [Route("navbar")]
        public  Task<bool> SaveNavBar(NavBar navbar){
            if(ModelState.IsValid){
                _repo.Add(navbar) ;
                return _repo.SaveAll();
            }else {
                return null;
            }
             
        }
    
    }
}