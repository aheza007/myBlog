using SimpleBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleBlog.Controllers
{
    public class AuthController: Controller
    {
        public ActionResult Login() {
            //new AuthLogin() { }
            return View();
        }
        [HttpPost]
        public ActionResult Login(AuthLogin formData,string returnUrl)
        {
            if(!ModelState.IsValid)
                return View(formData);

            //if (formData.username != "desire aheza")
            //{
            //    ModelState.AddModelError("CredentialMismatch", "We are sorry we don't know you");
            //    return View(formData);
            //}
            FormsAuthentication.SetAuthCookie(formData.username, true);
            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);
            return RedirectToRoute("home");
        }

        public ActionResult Logout(AuthLogin loggedInData) {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
    }
}