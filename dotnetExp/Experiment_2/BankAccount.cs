using System;
using System.Collections.Generic;
using System.Text;

    internal class BankAccount
    {
        private int accountNumber;
        private string accountName = string.Empty;
        private double balance;

        public BankAccount(){

        }
        public BankAccount(int accountNumber, string accountName,double balance)
        {
            this.accountNumber = accountNumber;
            this.AccountName = accountName;
            this.balance = balance;
        }

        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }

        public double Balance
        {
            get { return balance; }
        }


        public void deposit(double amount)
        {
            balance += amount;
            Console.WriteLine();
            Console.WriteLine("Deposite amount : " + amount);
            Console.WriteLine("New Balance : " +balance);
        }

        public void withdraw(double amount)
        {
            balance -= amount;
            Console.WriteLine();
            Console.WriteLine("Withdrow amount : " + amount);
            Console.WriteLine("New Balance : " + balance);

        }

        public void showDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Account Number : " + accountNumber);
            Console.WriteLine("Account Name : " + accountName);
            Console.WriteLine("Account Balance : " + balance);
        }
     }

