using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PunamFancyJewellers.DataLayer.DataModels;
using PunamFancyJewellers.DataLayer.ViewModels;

namespace PunamFancyJewellers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            var user = new User
            {
                Name = register.Name,
                Email = register.Email,
                UserName = register.Email,
            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user is not null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe ?? false, true);
                if (result.Succeeded)
                {
                    return Ok("Logged in successfully");
                }
            }
            return BadRequest("Invalid email or password");
        }
    }
}