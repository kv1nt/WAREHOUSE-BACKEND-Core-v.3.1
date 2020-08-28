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
        private UserService _loginService;

        public UserController(UserService loginService)
        {
            _loginService = loginService;
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

        [HttpPut("{userId}")]
        [AllowAnonymous]
        public IActionResult UpdateUser(UserModel updatedUser)
        {
            try
            {
                if (updatedUser != null)
                {
                   var user =  _loginService.UpdateUserInfo(updatedUser);
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
