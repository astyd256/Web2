using Microsoft.AspNetCore.Mvc;
using lab_2._4.Models;

namespace lab_2._4.Controllers
{
    public class Mockups : Controller
    {
        private UserModel? userModel;

        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains("userModel"))
            {
                userModel = HttpContext.Session.Get<UserModel>("userModel");
                if (userModel.isSignUp)
                return Redirect("SignUpCredentials");
            }
            else
            {
                userModel = new UserModel();
                HttpContext.Session.Set<UserModel>("userModel", userModel);
            }
            return Redirect("SignUp");
        }
        public IActionResult SignUp()
        {
            if (HttpContext.Session.Keys.Contains("userModel"))
            {
                userModel = HttpContext.Session.Get<UserModel>("userModel");
                if (userModel.isSignUp) return Redirect("SignUpCredentials");
            }
            else
            {
                userModel = new UserModel();
                HttpContext.Session.Set<UserModel>("userModel", userModel);
            }
            ViewBag.Submit = false;
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserModel user)
        {
            if (HttpContext.Session.Keys.Contains("userModel"))
            {
                UserModel oldUser = HttpContext.Session.Get<UserModel>("userModel");
                if (oldUser.isSignUp || user.isSignUp) return Redirect("SignUpCredentials");
                else if (oldUser.firstPartComplete) 
                {
                    user.firstName = oldUser.firstName;
                    user.lastName = oldUser.lastName;
                    user.day = oldUser.day;
                    user.month = oldUser.month;
                    user.year = oldUser.year;
                    user.gender = oldUser.gender;
                    user.isSignUp = true;
                    HttpContext.Session.Set<UserModel>("userModel", user);
                    return Redirect("SignUpCredentials");
                }
                else
                {
                    user.firstPartComplete = true;
                    HttpContext.Session.Set<UserModel>("userModel", user);
                    ViewBag.Submit = true;
                }
                return View();
            }
            else
            {
                userModel = new UserModel();
                HttpContext.Session.Set<UserModel>("userModel", userModel);
            }
            ViewBag.Submit = false;
            return View();
        }
        public IActionResult SignUpCredentials()
        {
            if (HttpContext.Session.Keys.Contains("userModel"))
            {
                userModel = HttpContext.Session.Get<UserModel>("userModel");
                if (userModel.isSignUp)
                {
                    ViewBag.firstName = userModel.firstName;
                    ViewBag.lastName = userModel.lastName;
                    ViewBag.day = userModel.day;
                    ViewBag.month = userModel.month;
                    ViewBag.year = userModel.year;
                    ViewBag.gender = userModel.gender;
                    ViewBag.email = userModel.email;
                    ViewBag.password = userModel.password;
                    return View();
                }
                else
                return View("SignUp");
            }
            else
            {
                UserModel userModel = new UserModel();
                HttpContext.Session.Set<UserModel>("userModel", userModel);
            }
            return View("SignUp");
        }
        public IActionResult PasswordReset()
        {
            ViewBag.Submit = 0;
            return View(); 
        }
        [HttpPost]
        public IActionResult PasswordReset(UserModel user, string userCode)
        {
            if (HttpContext.Session.Keys.Contains("userModel"))
            {
                userModel = HttpContext.Session.Get<UserModel>("userModel");
                if (userModel.isSignUp)
                {
                    int submit;
                    if (HttpContext.Session.Keys.Contains("submit")) submit = HttpContext.Session.Get<int>("submit");
                    else submit = 0;
                    if (submit == 0)
                    { 
                        if (userModel.email != user.email) // Wrong email
                        {
                            ViewBag.Error = "Wrong email!";
                            HttpContext.Session.Set<int>("submit", 0);
                            return View();
                        }
                        else // getting secret code
                        {
                        string code = "";
                        var random = new Random();
                        for (int i = 0; i < 8; i++)
                        {
                            code += random.Next(10).ToString();
                        }
                        HttpContext.Session.Set<int>("submit", 1);
                        HttpContext.Session.Set<string>("code", code);
                        ViewBag.Submit = 1;
                        ViewBag.code = code;
                        return View();
                        }
                    }
                    else if (submit == 1)
                    {
                        string code;
                        if (HttpContext.Session.Keys.Contains("submit")) code = HttpContext.Session.Get<string>("code");
                        else 
                        {
                            HttpContext.Session.Set<int>("submit", 0);
                            ViewBag.Submit = 0;
                            return View();
                        }
                        if (userCode == code)
                        {
                            HttpContext.Session.Set<int>("submit", 2);
                            ViewBag.Submit = 2;
                            return View();
                        }
                        else
                        {
                            ViewBag.error = "Wrong code!";
                            ViewBag.Submit = 1;
                            HttpContext.Session.Set<int>("submit", 1);
                            ViewBag.code = code;
                            return View();
                        }
                    }
                    else
                    {
                        userModel.password = user.password;
                        HttpContext.Session.Set<UserModel>("userModel", userModel);
                        return Redirect("SignUpCredentials");
                    }
                }
                else
                return View("SignUp");
            }
            return View("SignUp");
        }

    }
}
