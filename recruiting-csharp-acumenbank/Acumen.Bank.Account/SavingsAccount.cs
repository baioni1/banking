using System;


namespace Acumen.Bank.Account
{
    public class SavingsAccount
    {  //properties for savings account
        public string OwnerName { get; private set; }
        public double Balance { get; private set; }
        public double InterestRate { get; private set; }
        
        //constructor
        public SavingsAccount(string ownerName, double balance,double interestRate)
        {
            this.OwnerName = ownerName;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }
        //Deposit Method
        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposit a negative amount");
            }
            this.Balance += amount;
        }
        //Withdraw Method
        //using private to allow program to withdraw but not allowing the customer to directly withdraw
        private void Withdraw(double amount)
         {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw a negative amount");
            }
            this.Balance -= amount;
        }
        //Transfer Method
        public void Transfer(SavingsAccount destinationAccount, SavingsAccount sourceAccount, double amount)
        {
            sourceAccount.Withdraw(amount);
            destinationAccount.Deposit(amount);
        }
        //Compound Interest method
        public void ApplyInterest(int years)
        {
            //(1 +r/n)
            double body = 1 + (this.InterestRate);
            //nt
            double exponenet =  years;
            //P(1 +r/n) ^nt
            Balance = Balance * Math.Pow(body, exponenet);
        }
    }
    
}
