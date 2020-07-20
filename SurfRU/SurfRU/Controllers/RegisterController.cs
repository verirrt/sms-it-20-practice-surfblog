using SurfRU.DAL;
using SurfRU.Helpers;
using SurfRU.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SurfRU.Controllers
{
    public class RegisterController : Controller
    {

        SurfDbContext dbContext = new SurfDbContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(User model, HttpPostedFileBase imageData)
        {
            if (ModelState.IsValid)
            {
                // проводим регистрацию
                if  (model.Password != model.PasswordConfirm)
                {
                    ModelState.AddModelError(string.Empty, "Введённые не совпадают");
                    return View("Index", model);
                }

                var userInDb = dbContext.Users.FirstOrDefault(c => c.Nickname == model.Nickname);
                if (userInDb != null)
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с таким псевдонимом уже существует");
                    return View("Index", model);
                }

                userInDb = dbContext.Users.FirstOrDefault(d => d.Nickname == model.Nickname);
                if (userInDb != null)
                {
                    ModelState.AddModelError(string.Empty, "Такой e-mail уже зарегистрирован");
                    return View("Index", model);
                }
                
                if (imageData!=null)
                {
                    model.Photo = ImageSaveHelper.SaveImage(imageData);
                }

                dbContext.Users.Add(model);
                dbContext.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.Nickname, false);
                Session["UserId"] = model.Id.ToString();
                Session["Nickname"] = model.Nickname;
                Session["Photo"] = ImageUrlHelpers.GetUrl(model.Photo);

                return RedirectToAction("Index", "Feed");
            }
            return View("Index", model); 
        }
    }
}