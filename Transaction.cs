using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ATMSystem
{
    class Transaction
    {
        public static void Transactions()
        {
            double amount = 500.00;
            double deposit;
            int withdraw;
            double checkbal;

            while (true)
            {
                Console.WriteLine(" --------------------------");
                Console.WriteLine("| ATM SERVICE              |");
                Console.WriteLine("| 1. Check Balance         |");
                Console.WriteLine("| 2. Withdraw              |");
                Console.WriteLine("| 3. Deposit               |");
                Console.WriteLine("| 4. Exit                  |");
                Console.WriteLine(" --------------------------");
                Console.WriteLine("Select your option:\n");
                checkbal = int.Parse(Console.ReadLine());

                switch (checkbal)
                {
                    case 1:
                        Console.WriteLine("Your balance is: {0} \n", amount);
                        break;

                    case 2:
                        Console.WriteLine("Amount to be withdrawed");
                        withdraw = int.Parse(Console.ReadLine());
                        if (withdraw % 100 != 0)
                        {
                            Console.WriteLine("\n\nMinimum of 100 can be withdraw.", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ResetColor();
                        }
                        else if (withdraw > (amount - 200))
                        {
                            Console.WriteLine("\n\nInsufficient Fund", Console.ForegroundColor = ConsoleColor.Yellow);
                            Console.ResetColor();
                        }
                        else
                        {
                            amount = amount - withdraw;
                            Console.WriteLine("\nPlease take your money.");
                            Console.WriteLine("\nCurrent Balance is: {0}\n", amount);
                        }
                        using (StreamWriter sw = new StreamWriter(File.Create("C:\\Users\\ADMIN\\source\\repos\\ATMSystem\\ATMSystem\\WithdrawalReceipt.txt")))
                        {
                            sw.WriteLine("Amount Withdrawed: " + withdraw);
                            sw.WriteLine("Your Current Balance is: " + amount);
                            sw.Close();
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nEnter the amount to be deposited");
                        deposit = double.Parse(Console.ReadLine());
                        amount = amount + deposit;
                        Console.WriteLine("\n Current Balance is: {0}\n", amount);
                        using (StreamWriter sw = new StreamWriter(File.Create("C:\\Users\\ADMIN\\source\\repos\\ATMSystem\\ATMSystem\\DepositReceipt.txt")))
                        {
                            sw.WriteLine("Amount Deposited: " + deposit);
                            sw.WriteLine("Your Current Balance is: " + amount);
                            sw.Close();
                        }
                        break;

                    case 4:
                        Console.WriteLine("THANKYOU FOR USING OUR ATM SYSTEM. HAVE A GREAT DAY! :)", Console.ForegroundColor = ConsoleColor.Yellow);
                        Console.ResetColor();
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine($"Your choice {checkbal} is invalid! Please try again.", false, Console.ForegroundColor = ConsoleColor.Red);
                        Console.ResetColor();
                        break;

                }
            }
        }
    }
}
