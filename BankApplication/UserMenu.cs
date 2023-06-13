using BankApp.Core.Interface;
using BankApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class UserMenu : IUserMenu
    {
        private readonly IAccountServices _accountServices;
        private readonly ICreateAccountServices _createAccountServices;
        public UserMenu(IAccountServices accountServices, ICreateAccountServices createAccountServices)
        {
            _accountServices = accountServices;
            _createAccountServices = createAccountServices;
        }
        internal string option;
        public void Menu(Customer loggedInCustomer)
        {

            Console.WriteLine("\n 1: Creat Account\n 2: Check Balance\n 3: Deposit\n 4: Withdrawal");
            Console.WriteLine(" 5: Transfer\n 6: Account Details\n 7: Account Statement\n 8: Logout\n");
            Console.Write("Select any number to continue: ");
            option = Console.ReadLine();

            if (option == "1")
            {
                _createAccountServices.CreateAccountNumber(loggedInCustomer);
                Menu(loggedInCustomer);
            }
            else if (option == "2")
            {
                _accountServices.GetAccountBalance();
                Menu(loggedInCustomer);
            }
            else if (option == "3")
            {
                _accountServices.Deposit();
                Menu(loggedInCustomer);
            }
            else if (option == "4")
            {
                _accountServices.Withdrawal();
                Menu(loggedInCustomer);
            }
            else if (option == "5")
            {
                _accountServices.Transfer();
                Menu(loggedInCustomer);
            }
            else if (option == "6")
            {
                _accountServices.AccountDetailsTable();
                Menu(loggedInCustomer);
            }
            else if (option == "7")
            {
                _accountServices.StatementOfAccountTable();
                Menu(loggedInCustomer);
               // Console.WriteLine("Service Unavailable.");
            }
            else if (option == "8")
            {

                Console.Clear();
                Console.WriteLine("Thanks for banking with us");

            }
            else
            {
                Menu(loggedInCustomer);
            }
        }
    }
}
