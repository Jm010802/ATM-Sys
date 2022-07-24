using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ATMSystem
{
    class Login
    {
        public static void UserLogin()
        {
            
            Console.WriteLine("LOGIN YOUR ACCOUNT");
            string accountname, pincode, accountname1, pincode1 = string.Empty;

            Console.WriteLine("Enter accountname: ");
            accountname = Console.ReadLine();
            Console.WriteLine("Enter pincode: ");
            pincode = Console.ReadLine();

            using (StreamReader sr = new StreamReader(File.Open("C:\\Users\\ADMIN\\source\\repos\\ATMSystem\\ATMSystem\\CreateUser.txt", FileMode.Open)))
            {
                accountname1 = sr.ReadLine();
                pincode1 = sr.ReadLine();
                sr.Close();
            }

            if (accountname == accountname1 && pincode == pincode1)
            {
                Console.WriteLine("\nLogin Successful!\n", Console.ForegroundColor = ConsoleColor.Green);
                Console.ResetColor();
                Transaction.Transactions();
            }
            else
            {
                
                Console.WriteLine("\nYou have entered the incorrect information. Login Failed.", Console.ForegroundColor = ConsoleColor.Red);
                Console.WriteLine("Please login again.\n");
                Console.ResetColor();
                Login.UserLogin();
            }
            Console.Read();
        }
    }
}
