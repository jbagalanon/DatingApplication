﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {

            //validate request

            username = username.ToLower();

            if (await _userExists(username))
            {
                return BadRequest("username already exists");
            }

            else
            {
                var userToCreate = new User
                {
                    Username = username
                };
                var createdUser = await _repo.Register(userToCreate, password);

                return StatusCode(201);                             

            }

           
        }

    }
}