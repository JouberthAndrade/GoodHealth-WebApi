    using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Dto.Login
{
    public static class LoginSettings
    {
        public static string Secret = "E4B87C7A-132E-432B-81D2-01FAB767014F";
    }

    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
