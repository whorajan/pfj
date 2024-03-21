using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PunamFancyJewellers.DataLayer.DataModels;
using PunamFancyJewellers.DataLayer.ViewModels;
using PunamFancyJewellers.Helpers.EmailHelper;

namespace PunamFancyJewellers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IAccountEmail _accountEmail;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, IAccountEmail accountEmail)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _accountEmail = accountEmail;
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
                if (await SendRegistrationConfirmationEmail(user))
                    return Ok("User registered successfully, please check your email to confirm your account.");
                else
                    return Ok("User registered successfully, but confirmation email was not sent, please try to sign in and regenrate confirmation email.");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (code is null || userId is null) return NotFound();
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return NotFound();
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return Ok("Email confirmed successfully.");
            }
            else
            {
                return BadRequest("Unable to confirm email");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user is not null)
            {
                if (!user.EmailConfirmed)
                {
                    if (await SendRegistrationConfirmationEmail(user))
                        return Ok("Please check your email to confirm your account and sign in again.");
                    else
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Unable to send confirmation email.");
                }
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe ?? false, true);
                if (result.Succeeded)
                {
                    return Ok("Logged in successfully");
                }
            }
            return BadRequest("Invalid email or password");
        }

        private async Task<bool> SendRegistrationConfirmationEmail(User user)
        {
            string? code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (code is not null)
            {
                string? callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code }, protocol: HttpContext.Request.Scheme);
                if (callbackUrl is not null)
                {
                    if (await _accountEmail.SendRegistrationEmailAsync(_emailSender, user.Email, callbackUrl))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}