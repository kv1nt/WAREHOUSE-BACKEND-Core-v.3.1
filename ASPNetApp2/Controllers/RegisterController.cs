using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ASPNetApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private UserService _loginService;

        public RegisterController(UserService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody]UserModel user)
        {
            try
            {
                var newUser = _loginService.Register(user);

                if (newUser != null && user.Password == user.ConfirmPassword)
                {
                    return Ok($"User {newUser.Name} registerd syccessfully!");
                }
                else
                {
                    return BadRequest("User is registred or incorrect password...");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("{userId}")]
        public IActionResult GetUserById(string userId)
        {
            try
            {
                if (userId != null)
                {
                    var user = _loginService.GetUserById(userId);
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}