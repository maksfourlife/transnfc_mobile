using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Exceptions
{
    class NotEmail : Exception
    {
        public NotEmail() : base("Email does not match pattern") { }
    }
}
