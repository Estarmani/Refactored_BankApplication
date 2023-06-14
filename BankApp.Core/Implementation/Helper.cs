using BankApp.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Implementation
{
    public class Helper
    {
        public static List<Accounts> ReadFromAccountFile(string filepath)
        {
            List<Accounts> AllFetchedAccounts = new List<Accounts>();
            var lines = File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
               
                string[] fields = line.Split('|');
                fields = fields.Where(f => f != string.Empty).ToArray();
                
                if (fields.Length >= 4)
                {
                    var name = fields[0].Trim();
                    var accType = fields[1].Trim();
                    var accNo = fields[2].Trim();
                    var accBal = decimal.Parse(fields[3].Trim());

                    //\conversion of string to enum
                    AccountType AccTypee = (AccountType)Enum.Parse(typeof(AccountType), accType);

                    Accounts account = new Accounts();

                    account.FullName = name;
                    account.accountType = AccTypee;
                    account.AccountNo = accNo;
                    account.AccountBal = accBal;

                    AllFetchedAccounts.Add(account);
                }
               
            }
            
           /* using (var reader = new StreamReader(filepath))
            {
                string line;
                line = reader.ReadToEnd();
                while (line != null)
                {
                    string[] fields = line.Split('|');
                    if (fields.Length >= 4)
                    {
                        var name = fields[1].Trim();
                        var accType = fields[2].Trim();
                        var accNo = fields[3].Trim();
                        var accBal = decimal.Parse(fields[4].Trim()); 
                        
                    //\conversion of string to enum
                    AccountType AccTypee = (AccountType)Enum.Parse(typeof(AccountType), accType);

                    Accounts account = new Accounts();

                    account.FullName = name;
                    account.accountType = AccTypee;
                    account.AccountNo = accNo;
                    account.AccountBal = accBal;

                    AllFetchedAccounts.Add(account);
                    }                                                                            
                }
            }*/
            return AllFetchedAccounts;
        }
    }
}
