using BankApp.Core.Implementation;
using BankApp.Core.IMPLEMENTATION;
using BankApp.Core.Interface;
using BankApp.Core.INTERFACE;
using BankApplication;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddScoped<IAccountServices, AccountServices>();
services.AddScoped<ICreateAccountServices, CreateAccountServices>();
services.AddScoped<ICustomerServices, CustomerServices>();
services.AddScoped<IUserMenu,  UserMenu>();

services.AddSingleton<UserInterface>();

var serviceProvider = services.BuildServiceProvider();
var userinterface = serviceProvider.GetService<UserInterface>();

userinterface.Run();

