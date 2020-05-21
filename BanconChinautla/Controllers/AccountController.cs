using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BanconChinautla.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BanconChinautla.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var user = await userModel.Validar();
            if (user != null)
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim("Name", userModel.Username.ToString()));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));

                await HttpContext.SignInAsync("Identity.Application",
                   new ClaimsPrincipal(identity));

                return RedirectToAction("Index","Home", null,null);
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            string a = "";
            await HttpContext.SignOutAsync("Identity.Application");

            return RedirectToAction("Index", "Home", null, null);
        }
    }
}