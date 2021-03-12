using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ThanosApp.API.Data;
using ThanosApp.API.Dtos;
using ThanosApp.API.Models;

namespace ThanosApp.API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]

    public class AuthController : ControllerBase {
        private readonly IAuthrepository _repo;
        private readonly IConfiguration _config;

        public AuthController (IAuthrepository repo, IConfiguration config) {
            _repo = repo;
            _config = config;
        }

        [HttpPost]
        [Route ("register")]
        public async Task<IActionResult> Register (UserForRegisterDto userForRegisterDto) {
            //TODO: Validate Request
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            //Convert username to lowercase
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower ();

            if (await _repo.UserExist (userForRegisterDto.Username))
                return BadRequest ("Username already exists");

            var userToCreate = new User {
                Username = userForRegisterDto.Username
            };
            
            //var createduser = await _repo.Register (userToCreate, userForRegisterDto.Password);
            //return StatusCode (201);
            return Ok ();

        }

        [HttpPost ("login")]
        public async Task<IActionResult> login (UserForLoginDto userforlogindto) {
            var userFromRepo = await _repo.Login (userforlogindto.Username, userforlogindto.Password);
            if (userFromRepo == null)
                return Unauthorized ();
            var claims = new [] {
                new Claim (ClaimTypes.NameIdentifier, userFromRepo.Id.ToString ()),
                new Claim (ClaimTypes.Name, userFromRepo.Username)
            };
            //Create security key
            var key = new SymmetricSecurityKey (Encoding.UTF8
            .GetBytes (_config.GetSection ("AppSettings:Token").Value));

            //Signing credentials
            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);
           
            // set names and exp date

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor );

            return Ok (new {
                token = tokenHandler.WriteToken(token)
                });
        }
    }
}