using BankApp.Data;
using BankApp.Data.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.INTERFACE
{
    public interface ICustomerServices
    {
        Customer? customer { get; set; }
        void Register(RegisterDtos register);
        void Login(string email, string password);
        void Logout();
        
    }
}
