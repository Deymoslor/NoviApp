using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviApp.Application.Dtos.Users
{
    public class UserDto
    {
        public string UserName1 { get; set; } = null!;
        public string? UserName2 { get; set; }
        public string UserLastName1 { get; set; } = null!;
        public string? UserLastName2 { get; set; }
        public string? Email { get; set; } = null!;
        public string? UserPassword { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
}
