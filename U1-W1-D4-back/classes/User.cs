using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D4_back.classes
{
    public static class User
    {

        private static Dictionary<string, string> RegisteredUsers;

        public static string? UserLoggedIn { get; set; }
        public static DateTime? DateLogin { get; set; }
        public static List<string> AccessHistory { get; set; }

        static User()
        {
            RegisteredUsers = new Dictionary<string, string>
            {
                {"Alan","1234" },
                {"Claudio","12345" },
                {"Salvatore","123456" },
                {"Luigi","1234567" }
            };
            AccessHistory = new List<string>();
            UserLoggedIn = null;
            DateLogin = null;

        }


        public static void Menu()
        {
            Console.WriteLine("""

             MENU

             1.: Login

             2.: Logout

             3.: Verify login date and time

             4.: Access history

             5.: Exit

             """);


            //if (UserLoggedIn != null)
            //{
            //    Console.WriteLine(UserLoggedIn);
            //}
            string? choseNum = Console.ReadLine();


            switch (choseNum)
            {
                case "1":
                    User.Login();
                    break;
                case "2":
                    User.Logout();
                    break;
                case "3":
                    User.VerifyDate();
                    break;
                case "4":
                    User.AccessList();
                    break;
                case "5":
                    Console.WriteLine("Exit..");
                    Environment.Exit(0);
                    break;

                default:
                    Menu();
                    break;
            }
        }

        public static void Login()
        {

            if (UserLoggedIn != null)
            {
                Console.WriteLine("  An Account is already logged in, logout before try again!");
                Menu();
            }

            Console.Write("  Username: ");
            string? username = Console.ReadLine();

            Console.Write("  Password: ");
            string? password = Console.ReadLine();


            if (username == "" && password == "")
            {
                Console.WriteLine("  Invalid Username!");
                Menu();
            }


            if (RegisteredUsers.TryGetValue(username, out string thisPassword))
            {
                if (password == thisPassword)
                {
                    UserLoggedIn = username;
                    DateLogin = DateTime.Now;

                    string whoLogged = $"User: {username} Date: {DateLogin}";
                    AccessHistory.Add(whoLogged);

                    Console.WriteLine($"  Welcome Back {UserLoggedIn}");

                    Menu();
                }
            }
            else
            {
                Console.WriteLine("User not Found!");
                Menu();
            }
        }


        public static void Logout()
        {

            if (UserLoggedIn != null)
            {
                UserLoggedIn = null;
                DateLogin = null;

                Console.WriteLine("  Logout Success!");

                Menu();
            }
            else
            {
                Console.WriteLine("  No user logged in!");

                Menu();
            }
        }
        public static void VerifyDate()
        {

            if (UserLoggedIn != null)
            {
                Console.WriteLine($"  You logged in at: {DateLogin}");

                Menu();
            }
            else
            {
                Console.WriteLine("  No user logged in!");

                Menu();
            }
        }
        public static void AccessList()
        {

            Console.WriteLine("Access History:");
            if (AccessHistory.Count == 0)
            {
                Console.WriteLine("No Account logged today's");

                Menu();
            }
            else
            {
                foreach (string userLogged in AccessHistory)
                {

                    Console.WriteLine($"""

                        -{userLogged}
                        
                     """);
                }

                Menu();
            }
        }

    }
}
