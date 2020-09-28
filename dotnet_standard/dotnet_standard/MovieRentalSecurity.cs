using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dotnet_standard.Models;

namespace dotnet_standard
{
    public class MovieRentalSecurity
    {
        public static bool Login(string emailAddress, string password) {
            User user = new User();

            if (user.emailAddress == emailAddress && user.password == password) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}