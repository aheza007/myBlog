using SimpleBlog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Areas.Admin.ViewModels
{

    public class UsersIndex
    {
        public IEnumerable<User> Users { get; set; } 
    }

    public class NewUser
    {
        [Required, MaxLength(128)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
    public class UserEdit
    {
        [Required, MaxLength(128)]
        public string UserName { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }

    public class ResetUserPassWord
    {
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}