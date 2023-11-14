using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviApp.Domain.Entities
{
    public class User
    {
        public int Id_user { get; set; }
        public int user_name1 { get; set; }
        public int user_name2 { get; set; }
        public int user_lastName1 { get; set; }
        public int user_lastName2 { get; set; }
        public int email { get; set; }
        public int user_password { get; set; }
        public int phoneNumber { get; set; }
    }
}
