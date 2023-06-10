﻿using BankApp.Core.Implementation;
using BankApp.Core.Interface;
using BankApp.Core.INTERFACE;
using BankApp.Data;
using BankApp.Data.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.IMPLEMENTATION
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IUserMenu _UserMenu;
        public CustomerServices(IUserMenu UserMenu)
        {
            _UserMenu = UserMenu;
        }


        public Customer? customer { get; set; }

        public void Login(string email, string password)
        {
            if(customer.Email == email && customer.Password == password)
            {
                Console.Clear();
                Console.WriteLine("Login Successful.");
                _UserMenu.Menu();
                
            }
            else
            {
                Console.Clear() ;
                Console.WriteLine("Email or passwsord incorrect.");
                
            }
        }

        public void Logout()
        {
            Console.WriteLine("Thanks for banking with us.\n\n");
            Environment.Exit(0);
        }



        public void Register(RegisterDtos register)
        {

            customer = new Customer
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                Password = register.Password
            };

            using (StreamWriter writer = new StreamWriter("Database.txt", true))
            {
                writer.WriteLine($"{customer.FirstName} | {customer.LastName} | {customer.Email} | {customer.Password}");
            }
            Console.WriteLine($"customer {customer.FirstName} has been added to the file.");
        }
    }
}
