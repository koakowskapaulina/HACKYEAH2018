using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Route { get; set; }

        public User(int _UserID, string _Email, string _Password, string _Route)
        {
            UserID = _UserID;
            Email = _Email;
            Password = _Password;
            Route = _Route;
        }
    }
}
