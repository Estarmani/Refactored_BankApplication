using BankApp.Core.IMPLEMENTATION;
using BankApp.Core.Interface;
using BankApp.Core.INTERFACE;
using BankApp.Data;
using BankApp.Data.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class UserInterface
    {
        private readonly ICustomerServices _customerServices;
        
        public UserInterface(ICustomerServices customerServices, IUserMenu userMenu)
        {

            _customerServices = customerServices;
        }
        public static string? Option { get; set; }
        public void Run()
        {

            bool isValid;
            do
            {
                Console.WriteLine("\n                          ALLSTAR BANKING APPLICATION\n                          ");
                Console.WriteLine("\n 1: Sign Up\n 2: Login\n 3: Logout\n");
                Console.WriteLine("Select any number to begin ");
                Option = Console.ReadLine();
                Console.Clear();

                if (Option == "1")
                {
                    isValid = true;
                    var request = new RegisterDtos();
                    Console.WriteLine("\n                          ALLSTAR BANKING APPLICATION\n                          ");
                    Console.Write("\n\n\tEnter your First Name: ");
                    var firstName = Console.ReadLine();
                    request.FirstName = firstName;

                    Console.Write("\n\tEnter your Last Name: ");
                    var lastName = Console.ReadLine();
                    request.LastName = lastName;

                    Console.Write("\n\tEnter your Email: ");
                    var email = Console.ReadLine();
                    request.Email = email;

                    Console.Write("\n\tEnter your Password: ");
                    var password = Console.ReadLine();
                    request.Password = password;
                    _customerServices.Register(request);
                   // Console.Clear();
                    Console.WriteLine("Registration successful");

                }
                else if (Option == "2")
                {
                    isValid = true;
                    Console.Write("\n\n\t Enter your Email: ");
                    string UserEmail = Console.ReadLine();
                    Console.Write("\n\t Enter your Password: ");
                    var UserPassword = Console.ReadLine();

                    _customerServices.Login(UserEmail, UserPassword);
                    

                }
                else if (Option == "3")
                {
                    isValid = true;
                    _customerServices.Logout();

                }
                else
                {
                    isValid = false;
                    Run();
                }
            } while (isValid);

        }
    }
}
