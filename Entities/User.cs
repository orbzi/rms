using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public UserType userType { get; set; }
        public List<Booking> bookings { get; set; }

        public User(string _uname,string _password, string _email, string _phone)
        {
            username = _uname;
            password = _password;
            email = _email;
            phone = _phone;
            userType = null;
            bookings = null;
        }

        public User()
        {
            
        }
    }
}
