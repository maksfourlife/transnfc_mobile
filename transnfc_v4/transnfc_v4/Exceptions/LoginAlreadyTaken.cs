using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Exceptions
{
    class LoginAlreadyTaken : Exception
    {
        public LoginAlreadyTaken() : base("Login is already taken") { }
    }
}
