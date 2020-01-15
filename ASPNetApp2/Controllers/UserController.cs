using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private LoginService _loginService;


        public UserController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPut]
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
        [HttpPost]
        public IActionResult Login([FromBody]Login login)
        {

            try
            {
                var user = _loginService.Login(login);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return Ok(login);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}
