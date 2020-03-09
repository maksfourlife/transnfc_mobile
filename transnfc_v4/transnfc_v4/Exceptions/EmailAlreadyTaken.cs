using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Exceptions
{
    class EmailAlreadyTaken : Exception
    {
        public EmailAlreadyTaken() : base("Email already taken") { }
    }
}
