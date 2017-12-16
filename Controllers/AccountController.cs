using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using letskanban.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace letskanban.Controllers {
    public class AccountController : Controller 
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult New() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) 
        {
            var user = new User() { UserName = model.UserName, Email = model.EmailId };
            if(ModelState.IsValid)
            {
                var createdResult = await _userManager.CreateAsync(user,model.Password);
                if(createdResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user,false);
                    return RedirectToAction("Index","Home");
                }
                else 
                {
                    foreach(var error in createdResult.Errors) 
                    {
                        ModelState.AddModelError("",error.Description);

                    }
                }
                return View("New",model);
            }
            else
            {
                return View("New",model);
            }
            

        }

        [HttpPost]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,model.RememberMe,false);
                if(loginResult.Succeeded)
                {
                    return RedirectToAction("Index","Story");
                }
                else
                {
                    ModelState.AddModelError("","Could Not Login");
                    return View(model);
                }
            }
            else
            {
                return View();
            }
        }
    }
}