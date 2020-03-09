using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Exceptions
{
    class EmptyField : Exception
    {
        public EmptyField() : base("Fields are empty") { }
    }
}
