using BankApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Interface
{
    public interface IAccountServices
    {
        public void Deposit();
        public void Withdrawal();
        public void Transfer();
        public void GetAccountBalance();
        public void AccountDetailsTable();
        public string AccountDetails();
        public string AccountStatement();
        public void StatementOfAccountTable();
    }
}
