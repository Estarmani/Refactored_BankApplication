using BankApp.Core.Interface;
using BankApp.Core.Implementation;
using BankApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp;
using System.Security.Principal;

namespace BankApp.Core.Implementation
{
    public class AccountServices : IAccountServices
    {
       List<Activity> GetActivities = new List<Activity>();
        public async void Deposit()
        {
            

            Console.Clear();
            string line;
            Console.Write("\nEnter account to deposit: \n");
            var depositAccount = Console.ReadLine();
            // var account = CreateAccountServices.NewAccount.FirstOrDefault(x => x.AccountNo == depositAccount);

            Console.Write("Enter amount to deposit: ");
            var depositAmount = decimal.Parse(Console.ReadLine());


            // var index = CreateAccountServices.NewAccount.FindIndex(x => x.AccountNo == depositAccount);
            //CreateAccountServices.NewAccount[index] = account;
             var MyFetchedList = Helper.ReadFromAccountFile("Accountdata.txt");

            var accountToUpdate = MyFetchedList.FirstOrDefault(acc => acc.AccountNo == depositAccount);
            if (accountToUpdate is null)
            {
                Console.Clear();
                Console.WriteLine("Account number does not exist.");
            }
            else
            {
                accountToUpdate.AccountBal += depositAmount;
                Console.WriteLine("Deposit successful");
            }
            using (StreamWriter writer = new StreamWriter("Accountdata.txt", true))
            {
                foreach (var account in MyFetchedList)
                { writer.WriteLine($"|  {account.FullName,-10}  |  {account.accountType,-10}  |  {account.AccountNo,-10}  |  {account.AccountBal,-10}  |");
                }

            }




            //var activity = new Activity
            //    {
            //        ActivityDate = DateTime.Now,
            //        Description = "deposit",
            //        ActivityAmount = depositAmount,
            //        // ActivityBalance = account.AccountBal
            //    };
            //    GetActivities.Add(activity);
            


        }

        public void GetAccountBalance()
        {
            Console.Clear();
            Console.WriteLine("\n Enter account number to view balance");
            var accountNumber = Console.ReadLine();
            var account = CreateAccountServices.NewAccount.FirstOrDefault(x => x.AccountNo == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Account does not exist.");
            }

            Console.WriteLine($"Account balance for {accountNumber} is {account.AccountBal}");
        }

        public void Transfer()
        {
            Console.Clear();
            Console.Write("Enter account to transfer from: \n\n");
            var transferFromAccount = Console.ReadLine();
            var accountFrom = CreateAccountServices.NewAccount.Where(x => x.AccountNo == transferFromAccount).FirstOrDefault();

            Console.Write("Enter account to transfer to: \n\n");
            var transferToAccount = Console.ReadLine();
            var accountTo = CreateAccountServices.NewAccount.Where(x => x.AccountNo == transferToAccount).FirstOrDefault();

            Console.Write("Enter amount to transfer: ");
            var transferAmount = decimal.Parse(Console.ReadLine());

            if (accountFrom != null && accountTo != null && transferAmount > 0)
            {
                accountFrom.AccountBal -= transferAmount;
                accountTo.AccountBal += transferAmount;
                Console.Clear();
                Console.WriteLine("Transfer success.");
            }
            else
            {   
                Console.Clear();
                Console.WriteLine("An error occured.");
            }

            var activity = new Activity
            {
                ActivityDate = DateTime.Now,
                Description = $"Transfered to {accountTo}",
                ActivityAmount = transferAmount,
                ActivityBalance = accountFrom.AccountBal
            };
            GetActivities.Add(activity);
        }

        public void Withdrawal()
        {
            Console.Clear();
            Console.Write("Enter account to withdraw from: \n");
            var withdrawalAccount = Console.ReadLine();
            var account = CreateAccountServices.NewAccount.Where(x => x.AccountNo == withdrawalAccount).FirstOrDefault();
            Console.Write("Enter amount to withdraw: ");
            var withdrawalAmount = decimal.Parse(Console.ReadLine());

            if (account == null)
            {
                Console.WriteLine("Account does not exsit.");
            }
            else if (withdrawalAmount == 0)
            {
                Console.WriteLine("Insuficient fund");
            }
            else if(account.accountType == AccountType.savings && withdrawalAmount <= 1000)
            {
                Console.WriteLine("Account must have a minimum balance of 1000");
            }
            else
            {
                account.AccountBal -= withdrawalAmount;
                var index = CreateAccountServices.NewAccount.FindIndex(x => x.AccountNo == withdrawalAccount);
                CreateAccountServices.NewAccount[index] = account;
                Console.Clear();
                Console.WriteLine("Withdrawal successful.");

                var activity = new Activity
                {
                    ActivityDate = DateTime.Now,
                    Description = "Withdrawal",
                    ActivityAmount = withdrawalAmount,
                    ActivityBalance = account.AccountBal
                };
                GetActivities.Add(activity);
            }
        }
        public void AccountDetailsTable()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t|------------------|--------------------|---------------|--------------------|");
            Console.WriteLine("\t|   FULLNAME       |   ACCOUNT NUMBER   |  ACCOUNT TYPE |  ACCOUNT BALANCE   |");
            Console.WriteLine("\t|------------------|--------------------|---------------|--------------------|");
            Console.Write($"\t{AccountDetails()}\t");
            Console.WriteLine("\t|------------------|--------------------|---------------|--------------------|");

        }
        public void StatementOfAccountTable()
        {
            
                Console.WriteLine("\n\n\t|------------------|--------------------|---------------|--------------------|");
                Console.WriteLine("\t|       DATE       |    DESCRIPTION     |     AMOUNT    |       BALANCE      |");
                Console.WriteLine("\t|------------------|--------------------|---------------|--------------------|");
                Console.Write($"\t{AccountStatement()}\t");
                Console.WriteLine("\t|------------------|--------------------|---------------|--------------------|");
            
        }

        public string AccountDetails()
        {
            string printdetails = "";

            foreach (Accounts acc in CreateAccountServices.NewAccount)
            {
                printdetails += $"|  {acc.FullName,-14}  |  {acc.AccountNo,-16}  |  {acc.accountType,-11}  |  {acc.AccountBal,-17} |\n";
            }
            return printdetails;
        }
        public string AccountStatement()
        {
            string printdetails = string.Empty;
            foreach(Activity statement in GetActivities)
            {
                printdetails += $"|{statement.ActivityDate, -14} | {statement.Description, -16} | {statement.ActivityAmount, -11} | {statement.ActivityBalance, -17} |\n";
            }
            return printdetails;
        }
    }
}
