using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHealth.WebApi.Mapping.Login
{
    public class LoginMapDto
    {
        public LoginMapDto()
        {
        }

        public bool Authenticated { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
    }
}
