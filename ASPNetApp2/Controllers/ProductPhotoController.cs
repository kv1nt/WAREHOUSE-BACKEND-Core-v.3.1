using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ASPNetApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotoController : Controller
    {
        private FileService _fileService;
        public ProductPhotoController(FileService fileService)
        {
            _fileService = fileService;
        }

        [AllowAnonymous]
        [HttpGet]
        public  IActionResult GetProductsPhotos()
        {
            try
            {
                var productPhotos = _fileService.GetProductsPhotos();

                return Ok(productPhotos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductPhoto(string productId)
        {
            try
            {
                var productPhoto = await _fileService.GetProductPhotoByProductIDAsync(productId);

                return Ok(productPhoto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UploadUserPhoto([FromBody] ProductPhotoDTO photo)
        {
            try
            {
                _fileService.UploadProductPhoto(photo);

                return Ok("Product Photo saved successfylly");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}