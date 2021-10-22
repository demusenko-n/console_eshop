using System;

namespace SolidPL.Controllers
{
    public class MainPageController
    {
        public void DoSearch(string name)
        {
        }
        
        public void Index()
        {
            //User user = Application.Context.Session.CurrentUser;

            //Console.WriteLine("Welcome!");
            //Console.WriteLine($"Your role - {user.Role.RoleName}");
            //Console.WriteLine();

            //int counter = 0;

            //if (user.Role is GuestRole)
            //{
            //    Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandAuthLogin));
            //    Console.WriteLine($"{counter}. Log in");

            //    Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandSignLogin));
            //    Console.WriteLine($"{counter}. Sign up");
                
            //}
            //else
            //{
            //    Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandLogout));
            //    Console.WriteLine($"{counter}. Log out");
            //}

            //Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandProdList));
            //Console.WriteLine($"{counter}. Show all products");

            //Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandProdSearch));
            //Console.WriteLine($"{counter}. Search products");

            //if (user.Role is GuestRole) return;

            //Console.ForegroundColor = ConsoleColor.Green;

            //Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandCheckOrders));
            //Console.WriteLine($"{counter}. Show your orders");

            //Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandUserData));
            //Console.WriteLine($"{counter}. Change your user data");

            //Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandConfirmOrder));
            //Console.WriteLine($"{counter}. Confirm or cancel your order");

            //Console.ForegroundColor = ConsoleColor.White;

            //if (user.Role is not AdminRole) return;
            //Console.ForegroundColor = ConsoleColor.Red;

            //Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandManageUsers));
            //Console.WriteLine($"{counter}. Manage customer's data");

            //Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandManageProducts));
            //Console.WriteLine($"{counter}. Manage product list");

            //Actions.Add((++counter).ToString(), CommandContainer.GetCommand(CommandContainer.CommandManageOrders));
            //Console.WriteLine($"{counter}. Manage orders list");

            Console.ForegroundColor = ConsoleColor.White;

        }

    }
}