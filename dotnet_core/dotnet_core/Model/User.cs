using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core.Model
{
    public class User
    {
        public int userID { get; set; } = 1;
        public string fullName { get; set; } = "Tetora Nagumo";
        public string emailAddress { get; set; } = "test@gmail.com";
        public string password { get; set; } = "admin123";
    }
}
