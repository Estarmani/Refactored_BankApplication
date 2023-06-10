using BankApp.Data;

namespace BankApp.Core.Interface
{
    public interface IUserMenu
    {
        void Menu(Customer loggedInCustomer);
    }
}