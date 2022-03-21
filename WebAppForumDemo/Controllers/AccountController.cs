using Sciv.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sciv.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (userDTO.Password != userDTO.ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Password is not confirmed!";
                return View();
            }

            User user = new User
            {
                Email = userDTO.Email,
                UserName = userDTO.Username,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };

            IdentityResult result = await userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            List<IdentityError> errors = new List<IdentityError>(result.Errors);
            ViewData["errors"] = errors;

            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(userDTO.Username, userDTO.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewData["errorMessage"] = "Username or password is incorrect!";

            return View();
        }


        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit()
        {            
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
