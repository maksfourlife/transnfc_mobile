using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Exceptions
{
    class PasswordsMismatch : Exception
    {
        public PasswordsMismatch() : base("Passwords dont match") { }
    }
}
