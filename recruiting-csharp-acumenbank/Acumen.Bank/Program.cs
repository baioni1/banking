using System;
using System.Threading;
using Acumen.Bank.Account;

namespace Acumen.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Acumen Bank!");
		    Console.WriteLine();

		    CheckingAccount michaelsAccount = new CheckingAccount("Michael", 5000);
		    CheckingAccount gobsAccount = new CheckingAccount("Gob", 2000);
            // Initialize new savings account 
            SavingsAccount acesSavingsAccount = new SavingsAccount("Ace", 30000, 0.0089);
            SavingsAccount garysSavingsAccount = new SavingsAccount("Gary", 10000, .0056);

            Console.WriteLine("Open Accounts:");
		    Console.WriteLine();

            PrintAccountDetails(michaelsAccount);
		    Console.WriteLine();
		    PrintAccountDetails(gobsAccount);
            Console.WriteLine();
            PrintSavingsAccountDetails(acesSavingsAccount);
            Console.WriteLine();
            PrintSavingsAccountDetails(garysSavingsAccount);

            Console.WriteLine();
            Console.WriteLine("Making transfer of $1000.00...");
            try
            {   //thread will not execute for the amount specified
                Thread.Sleep(500);
            }
            catch (ThreadInterruptedException)
            {
                return;
            }
            //transfers amount between two accounts
            //Updates michaels account to reflect the withdraw from his account
            michaelsAccount.Transfer(gobsAccount, michaelsAccount, 1000);
            Console.WriteLine();

		    Console.WriteLine("Updated Account Details:");
		    Console.WriteLine();
		    PrintAccountDetails(michaelsAccount);
		    Console.WriteLine();
		    PrintAccountDetails(gobsAccount);

            // sample code for savings account implementation
            Console.WriteLine();
            Console.WriteLine("Making transfer of $5000.00...");
            try
            {   //thread will not execute for the amount specified
                Thread.Sleep(500);
            }
            catch (ThreadInterruptedException)
            {
                return;
            }
            //transfers money from one account to another
            acesSavingsAccount.Transfer(garysSavingsAccount, acesSavingsAccount, 5000);
            Console.WriteLine();

            Console.WriteLine("Updated Account Details:");
            Console.WriteLine();
            PrintSavingsAccountDetails(garysSavingsAccount);
            Console.WriteLine();
            PrintSavingsAccountDetails(acesSavingsAccount);
            Console.WriteLine();

            // apply 2 years of interest to the savings accounts
            acesSavingsAccount.ApplyInterest(2);
            garysSavingsAccount.ApplyInterest(2);
          
            PrintSavingsAccountDetails(acesSavingsAccount);
            Console.WriteLine();
            PrintSavingsAccountDetails(garysSavingsAccount);
            Console.WriteLine();


            Console.ReadLine();
        }

        private static void PrintAccountDetails(CheckingAccount account)
        {
		    Console.WriteLine("Checking Account for {0}:\r\n", account.OwnerName);
            Console.WriteLine("Checking Account Balance: {0:C2}\r\n", account.Balance);
           
	    }
        static void PrintSavingsAccountDetails(SavingsAccount savingsAccount)
        {
            Console.WriteLine("Savings Account for {0}:\r\n", savingsAccount.OwnerName);
            Console.WriteLine("Savings Account Balance: {0:C2}\r\n", savingsAccount.Balance);

        }
    }
}
