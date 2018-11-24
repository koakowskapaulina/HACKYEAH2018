using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Models
{
    public class User
    {
        public long UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
        }

        public User(long _UserID, string _Email, string _Password)
        {
            UserID = _UserID;
            Email = _Email;
            Password = _Password;
        }
    }
}
