using System;

namespace Acumen.Bank.Account
{
    public class CheckingAccount
    {
        public string OwnerName { get; private set; }
        public double Balance { get; private set; }

        public CheckingAccount(string ownerName, double balance)
        {
            this.OwnerName = ownerName;
            this.Balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposit a negative amount");
            }
            this.Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw a negative amount");
            }
            this.Balance -= amount;
        }
        //Transfer Method
        public void Transfer(CheckingAccount destinationAccount, CheckingAccount sourceAccount, double amount)
        {  
            sourceAccount.Withdraw(amount);
            destinationAccount.Deposit(amount); 
        }
        
    }
}
