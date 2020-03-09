using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Exceptions
{
    class InccorrectPassword : Exception
    {
        public InccorrectPassword() : base("Icorrect password") { }
    }
}
