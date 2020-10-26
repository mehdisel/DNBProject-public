using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBProject.BLL.UserManagement;
using DNBProject.Entities.Entity;
using DNBProject.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DNBProject.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _user;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService user, ILogger<UserController> logger)
        {
            _user = user;
            _logger = logger;
        }
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["userID"])|| !string.IsNullOrEmpty(HttpContext.Session.GetString("userID")))
            {

                HttpContext.Session.SetString("userID",Request.Cookies["userID"].ToString());
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login([Bind(include: "UserName,Password,RememberMe,UserID")]UserLoginViewModel user)
        {
            User loginingUser = _user.Get(user.UserName, user.Password);
            if (loginingUser!=null)
            {
                HttpContext.Session.SetString("userName", loginingUser.UserName);
                HttpContext.Session.SetString("userID", loginingUser.ID.ToString());
                if (user.RememberMe)
                {
                    Response.Cookies.Append("userName", loginingUser.UserName);
                    Response.Cookies.Append("userID", loginingUser.ID.ToString());
                }
                return Json(new { incorrectLogin = false, url = Url.Action("Index", "Product"),message="Giriş başarılı." });
            }
            else
            {
                return Json(new { incorrectLogin=true, message="hatalı giriş." });
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("userName");
            Response.Cookies.Delete("userID");
            return RedirectToAction("Login", "User");
        }
    }
}
