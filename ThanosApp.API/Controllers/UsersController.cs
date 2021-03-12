using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThanosApp.API.Data;
using ThanosApp.API.Dtos;

namespace ThanosApp.API.Controllers {    
    [Route ("api/[controller]")]
    [ApiController]
    //[Authorize]
        public class UsersController : ControllerBase {
        public readonly IThanosRepository _repo;
        private readonly IMapper _mapper;

        public UsersController (IThanosRepository repo, IMapper mapper) {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet] 
        public async Task<IActionResult> GetUsers () {
            var users = await _repo.GetUsers ();
            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>> (users);
            return Ok (userToReturn);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetUser (int Id) {
            var user = await _repo.GetUser (Id);
            var userToReturn = _mapper.Map<UserForDetailedDto> (user);
            return Ok (userToReturn);
        }
    }
}