using Microsoft.VisualBasic;

partial class User
{

    int UserID { set; get; }
    string UserName { set; get; }
    string UserEmail { set; get; }
    string UserPhone { set; get; }

    public User(int userID, string userName, string userEmail, string userPhone)
    {
        UserID = userID;
        UserName = userName;
        UserEmail = userEmail;
        UserPhone = userPhone;
    }



    static List<User> Users = new List<User>();
    public static void AddUser(User user)
    {
        bool IsUserExist = false;
        // foreach (var u in Users)
        // {
        //     if (u.UserID == user.UserID)
        //     {
        //         Console.WriteLine($"User With ID {user.UserID} already Exist");
        //         IsUserExist = true;
        //         break;
        //     }
        // }

        if (CheckID(user.UserID))
        {
            Console.WriteLine($"User With ID {user.UserID} already Exist");
            IsUserExist = true;
        }
        if (!IsUserExist)
        {
            Users.Add(user);
            Console.WriteLine($"User With ID {user.UserID} has been added Succesfully");
        }
    }




    public static void DeleteUser(int userId)
    {
        var user = Users.FirstOrDefault(u => u.UserID == userId);
        if (user != null)
        {
            Users.Remove(user);
            Console.WriteLine($"User With ID {userId} is deleted Succesfully");
        }
        else
        {
            Console.WriteLine($"User With ID {userId} doesn't Exist");
        }
    }

    public static void UpdateUser(int userId, DataToUpdate updateData)
    {
        if (Users.FirstOrDefault() != null)
        {
            bool IsUserExist = false;
            updateData--;
            foreach (var u in Users)
            {
                if (u.UserID == userId)
                {
                    Console.Write("New Data: ");
                    string? input = Console.ReadLine();
                    if (input != null)
                    {
                        switch (updateData)
                        {
                            case DataToUpdate.ID:
                                var id = GetID(input);
                                if (!CheckID(id))
                                    u.UserID = id;
                                else
                                    Console.WriteLine($"User With ID {id} already Exist");
                                break;
                            case DataToUpdate.Name:
                                u.UserName = input;
                                break;
                            case DataToUpdate.Phone:
                                u.UserPhone = input;
                                break;
                            case DataToUpdate.EMail:
                                u.UserEmail = input;
                                break;
                            default:
                                Console.WriteLine("Invalid Operation Code....");
                                break;
                        }
                    }
                    IsUserExist = true;
                    break;
                }
            }
            if (!IsUserExist)
            {
                Console.WriteLine($"User With ID {userId} doesn't Exist");
            }

        }
        else
        {
            Console.WriteLine("There are no users to update........");
        }
    }

    public static void ShowUsers()
    {
        Console.WriteLine("************************** All Users In System **************************");
        if (Users.FirstOrDefault() != null)
        {
            foreach (var u in Users)
            {
                Console.WriteLine(u);
            }
        }
        else
        {
            Console.WriteLine("There are no users to Show........");

        }
        Console.WriteLine("*************************************************************************");
    }

    public override string ToString()
    {
        return $"{{\n ID:{UserID}\n Name:{UserName}\n Email:{UserEmail}\n Phone:{UserPhone}\n}}";
    }

    private static int GetID(string input)
    {
        bool success = int.TryParse(input, out int number);
        if (!success)
        {
            Console.WriteLine("Id should include only numbers");
        }
        return number;
    }

    private static bool CheckID(int id)
    {

        foreach (var u in Users)
        {
            if (u.UserID == id)
            {
                return true;
            }
        }
        return false;
    }

}


