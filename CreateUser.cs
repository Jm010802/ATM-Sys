using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ATMSystem
{
    class CreateUser
    {
        public static void UserCreation()
        {
            Console.WriteLine("Now we create a new user");

            string accountname;

            Console.WriteLine("Enter account name: ");
            accountname = Console.ReadLine().Trim();


            Console.WriteLine("Enter your pin code: ");
            string pincode1 = Console.ReadLine().Trim();

            bool notsuccess = false;
            int pin;
            bool parseSuccess1 = int.TryParse(pincode1, out pin);
            string pincode;


            if (pincode1.Length == 6 && parseSuccess1)
            {
                notsuccess = false;
                pincode = pincode1;
            }
            else
            {
                notsuccess = true;
                Console.WriteLine("The password must be a number and have at least 6 digit pincode.", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
            }

            if (notsuccess == true)
            {
                do
                {
                    Console.WriteLine("Enter your pincode: ");
                    pincode = Console.ReadLine();
                    bool parseSuccess = int.TryParse(pincode, out pin);
                    if (pincode.Length == 6 && parseSuccess)
                    {
                        notsuccess = false;
                        Console.WriteLine("\nYour pincode was accepted.\n", Console.ForegroundColor = ConsoleColor.Green);
                        Console.ResetColor();
                        using (StreamWriter sw = new StreamWriter(File.Create("C:\\Users\\ADMIN\\source\\repos\\ATMSystem\\ATMSystem\\CreateUser.txt")))
                        {
                            sw.WriteLine(accountname);
                            sw.WriteLine(pincode);
                            sw.Close();
                        }
                        CreateUser.UserLogin();
                    }
                    else
                    {
                        notsuccess = true;
                        Console.WriteLine("The password must be a number and have at least 6 digit pincode.", Console.ForegroundColor = ConsoleColor.Red);
                        Console.ResetColor();
                    }
                }
                while (notsuccess == true);
            }
            else
            {
                Console.WriteLine("\nYour pincode was accepted.\n", Console.ForegroundColor = ConsoleColor.Green);
                Console.ResetColor();
                using (StreamWriter sw = new StreamWriter(File.Create("C:\\Users\\ADMIN\\source\\repos\\ATMSystem\\ATMSystem\\CreateUser.txt")))
                {
                    sw.WriteLine(accountname);
                    sw.WriteLine(pincode1);
                    sw.Close();
                }
                CreateUser.UserLogin();
            }
        }
            static void UserLogin() {
            string YesNo;
            {
                do
                {
                    Console.WriteLine("Do you want to login your account?");
                    Console.WriteLine("Yes or No?");
                    YesNo = Console.ReadLine().ToUpper().Trim();

                    if (YesNo != "YES" && YesNo != "NO")
                    {
                        Console.WriteLine($"Your choice {YesNo} is invalid! Please try again.", Console.ForegroundColor = ConsoleColor.Red);
                        Console.ResetColor();
                        CreateUser.UserLogin();
                    }
                    else if (YesNo.ToUpper() == "YES")
                    {
                        Login.UserLogin();
                    }
                    while (YesNo != "YES" && YesNo != "NO") ;
                }
                while (YesNo.ToUpper() != "NO");
                Console.WriteLine("Exiting the system... Don't worry your account was successfully saved. :)", Console.ForegroundColor = ConsoleColor.Yellow);
                Console.ResetColor();
                System.Environment.Exit(0);
            }
        }
    }
}
