using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SurfRU.DAL;
using SurfRU.Models.ViewModels;
using System.Web.Security;
using SurfRU.Helpers;

namespace SurfRU.Controllers
{
    public class HomeController : Controller
    {
        SurfDbContext dbContext = new SurfDbContext();

        public ActionResult Index(LoginViewModel model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(
                    c => c.Nickname == model.Nickname &&
                    c.Password == model.Password
                    );

                if (userInDb != null)
                {
                    FormsAuthentication.SetAuthCookie(userInDb.Nickname, model.RememberMe);
                    Session["UserId"] = userInDb.Id.ToString();
                    Session["Nickname"] = userInDb.Nickname;
                    Session["Photo"] = ImageUrlHelpers.GetUrl(userInDb.Photo);

                    return RedirectToAction("Index", "Feed");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный псевдоним или пароль");
                }
            }

            return View("Index", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Request.Cookies.Clear();

            return RedirectToAction("Index");
        }       

    }
}