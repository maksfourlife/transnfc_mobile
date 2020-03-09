using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Exceptions
{
    class EmailNotFound : Exception
    {
        public EmailNotFound() : base("User with such email is not found") { }
    }
}
