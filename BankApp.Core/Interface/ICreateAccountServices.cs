﻿using BankApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Interface
{
    public interface ICreateAccountServices
    {
        string CreateAccountNumber(Customer loggedInCustomer);
    }
}
