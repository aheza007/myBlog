using SimpleBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Areas.Admin.ViewModels
{

    public class UsersIndex
    {
        public IEnumerable<User> Users { get; set; } 
    }
}