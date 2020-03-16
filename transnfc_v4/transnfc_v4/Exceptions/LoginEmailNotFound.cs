﻿using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4.Exceptions
{
    class LoginEmailNotFound : Exception
    {
        public LoginEmailNotFound() : base("User with such login is not found") { }
    }
}
