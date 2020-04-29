using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Dtos;
using DatingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        private Task<bool> userExists(string username)
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            //validate request

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
            {

                return BadRequest("username already exists");
            }

            

            else
            {
                var userToCreate = new User
                {
                    Username = userForRegisterDto.Username
                };
                var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
                
            }
            return StatusCode(201);


        }

        [HttpPost("Login")]
        public Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }


        }
     
    }
}
