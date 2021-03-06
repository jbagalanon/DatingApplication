﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPI.Dtos
{
    public class UserForRegisterDto
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "You must specify password at least 4")]
        public string Password { get; set; }
    }
}
