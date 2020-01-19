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
                var ph = photo;

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

    }
}