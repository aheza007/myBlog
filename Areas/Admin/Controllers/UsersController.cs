using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using SimpleBlog.Models;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("users")]
    public class UsersController : Controller
    {

        public ActionResult Index()
        {
            return View(new UsersIndex
            {
                //get all users from our database as a list
                Users = Database.Session.Query<User>().ToList()
            });
        }

        public ActionResult New()
        {
            // return Content("tESTING");
            //View(string viewName, object model);
            return View("NewUser",new NewUser{
               
            });
           
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(NewUser user) {
            
            if (Database.Session.Query<User>().Any(u => u.Username == user.UserName))
                ModelState.AddModelError("Username","username must be Unique");
           
            if (!ModelState.IsValid) {
                return View("NewUser", user);
            }
            var usr=new User{
                Username=user.UserName,
                Email=user.Email
            };
            usr.SetPassword(user.PassWord);
            Database.Session.Save(usr);
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
                return HttpNotFound();
            return View("EditUser", new UserEdit
            {
                UserName=user.Username,
                Email=user.Email
            });

        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEdit form)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
                return HttpNotFound();

            if (Database.Session.Query<User>().Any(u => u.Username == form.UserName && u.Id != id))
                ModelState.AddModelError("Username","Username already taken");
            if (!ModelState.IsValid)
                return View("EditUser",form);
            user.Username = form.UserName;
            user.Email = form.Email;
            Database.Session.Update(user);
            return RedirectToAction("index");
        }

        public ActionResult Reset(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
                return HttpNotFound();
            return View("ResetUserPassword", new ResetUserPassWord
            {
                UserName = user.Username,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Reset(int id, ResetUserPassWord form)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
                return HttpNotFound();
            form.UserName=user.Username;
            
            if (!ModelState.IsValid)
                return View("ResetUserPassword", form);
            user.SetPassword(form.PassWord);
            Database.Session.Update(user);
            return RedirectToAction("index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var user = Database.Session.Load<User>(id);

            if (user ==null )
                return HttpNotFound(); 

            Database.Session.Delete(user);
            return RedirectToAction("index");
        }

    }
}
