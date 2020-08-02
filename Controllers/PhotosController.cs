﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingAPI.Data;
using DatingAPI.Dtos;
using DatingAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DatingAPI.Controllers
{

    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController :ControllerBase
    {
        private readonly IDatingRepository _repo;
        private IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IDatingRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repo = repo;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
                );


            _cloudinaryConfig = new CloudinarySettings(acc);
        }
        [HttpPost]
        public async Task<IActionResult>AddPhotoForUser(int userId,PhotoForCreationDto photoForCreationDto)
    }
}
