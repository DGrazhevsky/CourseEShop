using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WineS.Models
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
    }
}