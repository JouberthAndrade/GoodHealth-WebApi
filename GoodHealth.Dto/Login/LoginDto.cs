using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Dto.Login
{
    public class LoginDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
    }
}
