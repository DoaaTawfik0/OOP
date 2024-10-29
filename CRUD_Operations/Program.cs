using System;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic;

static partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("************************** CRUD Operations System **************************");

        bool keepWork = true;
        while (keepWork)
        {
            ShowOptions();
            Console.WriteLine("-----------------------------------------");

            var key = Console.ReadKey().Key;
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");

            if (key == ConsoleKey.RightArrow)
            {
                Console.WriteLine("Right arrow key pressed. Exiting program...");
                break;
            }
            else
            {
                switch (key)
                {
                    case ConsoleKey.D1:
                        if (!GetUserData())
                            Console.WriteLine("You Must Enter Data for all fields");
                        break;
                    case ConsoleKey.D2:
                        if (!DeleteUserData())
                            Console.WriteLine("You Must Enter ID");
                        break;
                    case ConsoleKey.D3:
                        if (!UpdateUserData())
                            Console.WriteLine("You Must Enter Option and ID");
                        break;
                    case ConsoleKey.D4:
                        User.ShowUsers();
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;
                }

            }
            Thread.Sleep(1500);
            Console.Clear();
        }




    }

    public static void ShowOptions()
    {
        Console.WriteLine();
        Console.WriteLine("To Add User    -> Enter 1");
        Console.WriteLine("To Delete User -> Enter 2");
        Console.WriteLine("To Update User -> Enter 3");
        Console.WriteLine("To Show Users  -> Enter 4");
        Console.WriteLine("To End Program -> Enter RightArrow");
    }

    private static bool GetUserData()
    {
        Console.WriteLine();

        Console.Write("ID: ");
        int d1;
        while (!int.TryParse(Console.ReadLine(), out d1))
        {
            Console.Write("Invalid ID. Please enter a numeric ID: ");
        }
        Console.Write("Name: ");
        string? d2 = Console.ReadLine();
        Console.Write("Email: ");
        string? d3 = Console.ReadLine();
        Console.Write("Phone: ");
        string? d4 = Console.ReadLine();

        if (string.IsNullOrEmpty(d2) || string.IsNullOrEmpty(d3) || string.IsNullOrEmpty(d4))
        {
            return false;
        }

        User user = new User(d1, d2, d3, d4);
        User.AddUser(user);

        return true;
    }

    private static bool DeleteUserData()
    {
        Console.WriteLine();

        Console.Write("UserID: ");
        var check = int.TryParse(Console.ReadLine(), out int id);
        if (check == false)
            return false;
        User.DeleteUser(id);
        return true;

    }

    private static bool UpdateUserData()
    {
        Console.WriteLine();

        Console.WriteLine("Enter 1 to update User ID");
        Console.WriteLine("Enter 2 to update User Name");
        Console.WriteLine("Enter 3 to update User Email");
        Console.WriteLine("Enter 4 to update User Phone");
        Console.WriteLine("-----------------------------------------");

        var check = int.TryParse(Console.ReadLine(), out int option);

        Console.Write("Enter ID of user you want to update: ");
        check &= int.TryParse(Console.ReadLine(), out int id);
        if (check == false)
            return false;
        User.UpdateUser(id, (DataToUpdate)option);
        return true;
    }
}
