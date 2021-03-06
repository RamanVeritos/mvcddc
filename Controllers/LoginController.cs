﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [HandleError]
    public class LoginController : Controller
    {
       
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","login");
        }
        [HttpPost]
        public ActionResult Login(tbusr model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ddc_login2Entities())
                {
                    bool IsValidUser = context.tbusrs.Any(user => user.usrnam.ToLower() ==
                         model.usrnam.ToLower() && user.usrpwd == model.usrpwd);
                    if (IsValidUser)
                    {
                        FormsAuthentication.SetAuthCookie(model.usrnam, false);
                        return RedirectToAction("Ad_Seach_Prac", "Main");
                    }
                    ModelState.AddModelError("","invalid Username or Password");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
           
        }

    }
}