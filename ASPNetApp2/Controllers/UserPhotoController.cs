using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ASPNetApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPhotoController : ControllerBase
    {
        private FileService _fileService;
        public UserPhotoController(FileService fileService)
        {
            _fileService = fileService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UploadUserPhoto([FromBody] UserPhotoDTO photo)
        {
            try
            {
                _fileService.UploadUserPhoto(photo);

                return Ok("User Phtoto saver successfylly");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserPhoto(string userId)
        {
            try
            {
               var userPhoto =   _fileService.GetUserPhotoByUserID(userId);

                return  Ok(userPhoto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult UpdateUserPhoto(UserPhotoDTO photo)
        {
            try
            {
                _fileService.UpdateUserPhoto(photo);

                return Ok("User photo updated successfully ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

    }
}