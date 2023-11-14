using System;
using System.Collections.Generic;

namespace NoviApp.API.Configurations
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string UserName1 { get; set; } = null!;
        public string? UserName2 { get; set; }
        public string UserLastName1 { get; set; } = null!;
        public string? UserLastName2 { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
