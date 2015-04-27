using SimpleBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    public class AuthController: Controller
    {
        public ActionResult Login() {

            return View(new AuthLogin() { });
        }
        [HttpPost]
        public ActionResult Login(AuthLogin formData)
        {
            if(!ModelState.IsValid)
                return View(formData);

            if (formData.username != "desire aheza")
            {
                ModelState.AddModelError("CredentialMismatch", "We are sorry we don't know you");
                return View(formData);
            }
            
            return Content("Hii, "+formData.username);
        }
    }
}