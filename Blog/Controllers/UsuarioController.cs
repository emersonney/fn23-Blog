using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {
    

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

  

        [HttpPost]
        public IActionResult Autentica(Login model)
        {
            //ViewBag.ReturnUrl = returnUrl;

            if (ValidaLogin(model))
            {
                var claims = new List<Claim>
                {
                    new Claim("user",model.LoginName),
                    new Claim("role","Member")
                };
           


            var principal = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                "user", "role");
            //await
            HttpContext.SignInAsync(new ClaimsPrincipal(principal)).Wait();

                
                //if(Url.IsLocalUrl(returnUrl))
                //{
                   // return Redirect(returnUrl);
                //}

               


            }
                return Redirect("/");
           


       

        }

        private bool ValidaLogin(Login model)
        {
            return true;
        }
    }
}