using BankApp.Core.Interface;
using BankApp.Data;
using BankApp.Data.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Implementation
{
    public class CreateAccountServices : ICreateAccountServices
    {
        public static List<Accounts> NewAccount = new();
        string option { get; set; }
        int accNo { get; set; }
       
        public string CreateAccountNumber(Customer loggedInCustomer)
        {


            Console.Clear();
            Console.WriteLine("\n                          ALLSTAR BANKING APPLICATION          \n");
            Console.WriteLine("\n 1: Savings Account\n 2: Current");
            Console.WriteLine("\n Select any number to create an account \n");
            option = Console.ReadLine();

            if (option == "1")
            {
                Console.Clear();
                Random newAccount = new Random();
                accNo = newAccount.Next(10000000, 29999999);
                string result = "00" + accNo.ToString();
                //Customer customer = new Customer();
                var account = new Accounts
                {
                    AccountBal = 1000,
                    AccountNo = result,
                    accountType = Data.AccountType.savings,
                    FullName = loggedInCustomer.FirstName + " " + loggedInCustomer.LastName,
                };
                NewAccount.Add(account);

                using (StreamWriter writer = new StreamWriter("Accountdata.txt", true))
                {
                    writer.WriteLine($"{account.FullName,-10}  |  {account.accountType,-10}  |  {account.AccountNo,-10}  |  {account.AccountBal,-10}|\n");
                }
                Console.WriteLine("\nSavings Account created successfully");
                Console.WriteLine(result);
                return result;

            }
            else if (option == "2")
            {
                Console.Clear();

                Random newAccount = new Random();
                accNo = newAccount.Next(100000000, 199999999);
                string result = "1" + accNo.ToString();
                //Customer customer = new Customer();
                var account = new Accounts
                {
                    AccountBal = 0,
                    AccountNo = result,
                    accountType = Data.AccountType.current,
                    FullName = loggedInCustomer.FirstName + " " + loggedInCustomer.LastName,
                };
                NewAccount.Add(account);

                using (StreamWriter writer = new StreamWriter("Accountdata.txt", true))
                {
                    writer.WriteLine($"{account.FullName,-10} | {account.accountType,-10} | {account.AccountNo,-10} | {account.AccountBal,-10}");
                }
                Console.WriteLine("\nCurrent Account created successfully");
                Console.WriteLine(result);
                return result;
            }
            else
            {
                CreateAccountNumber(loggedInCustomer);
            }
            return string.Empty;

        }
    }
}
