using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using Review4_.NET.ViewModels;
using Review4_.NET.Models;

namespace Review4_.NET.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, 
                                 SignInManager<User> signInManager, 
                                 MyContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new User { UserName = model.UserName , Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            { return RedirectToAction("Index"); }
            else { return View(); }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager
                                                                        .PasswordSignInAsync
                                                                            (model.UserName, model.Password, 
                                                                             isPersistent: true, 
                                                                             lockoutOnFailure: false);
            if (result.Succeeded) { return RedirectToAction("Index"); }
            else { return View(); } 
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
