using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Models;

namespace MVC_Demo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public List<UserModel> PutValue()
        {
            var users = new List<UserModel>
            {
                new UserModel{UserName="xuantruong",Password="12345" },

                new UserModel{UserName="xuanquang",Password="12345" }
            };         

            return users;
        }

        //Check account password
        [HttpPost]
        public IActionResult VerifyAccount(UserModel userAccount)
        {
            var account = PutValue();

            if (account.Any(x => x.Equals(userAccount)))
            {
                ViewBag.message = "Login Success";
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Login");
            }
        }
    }
}
