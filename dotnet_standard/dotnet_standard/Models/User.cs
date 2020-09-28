using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnet_standard.Models
{
    public class User
    {
        public int userID { get; set; } = 1;
        public string fullName { get; set; } = "Tetora Nagumo";
        public string emailAddress { get; set; } = "test@gmail.com";
        public string password { get; set; } = "admin123";
    }
}