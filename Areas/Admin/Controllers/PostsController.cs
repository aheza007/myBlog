using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Infrastructure;
using SimpleBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
namespace SimpleBlog.Areas.Admin.Controllers
{
    [Authorize(Roles="admin")]
    [SelectedTab("posts")]
    public class PostsController:Controller
    {
  
        public ActionResult Index() {
            //return Content("Hii, Admin");
            List<User> ist = new List<User>();
            ist = Database.Session.Query<User>().ToList();
            return View(new UsersIndex { 
                //get all users from our database as a list
                Users= Database.Session.Query<User>().ToList()
            });
        }
    }
}