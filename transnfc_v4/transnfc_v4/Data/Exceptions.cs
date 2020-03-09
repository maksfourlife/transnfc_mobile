using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Data
{
    class PasswordsDontMatchException : Exception
    {
        public PasswordsDontMatchException() : base("Passwords dont match") { }
    }

    class EmptyFieldException : Exception
    {
        public EmptyFieldException() : base("Fields are empty") { }
    }

    class AlreadyTakenFirstNameException : Exception
    {
        public AlreadyTakenFirstNameException() : base("First name already taken") { }
    }

    class AlreadyTakenLastNameException : Exception
    {
        public AlreadyTakenLastNameException() : base("Last name already taken") { }
    }

    class AlreadyTakenEmailException : Exception
    {
        public AlreadyTakenEmailException() : base("Email already taken") { }
    }

    class NotEmailException : Exception
    {
        public NotEmailException() : base("Email does not match pattern") { }
    }
}
