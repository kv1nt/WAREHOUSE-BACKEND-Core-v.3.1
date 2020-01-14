using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetApp2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private LoginService _loginService;


        public UserController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Guid id)
        {

            try
            {

                if (_loginService.Login(id))
                {
                    return Ok("User logined successfully!");
                }
                else
                {
                    return NotFound("User not found! Please Register the user... ");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}
