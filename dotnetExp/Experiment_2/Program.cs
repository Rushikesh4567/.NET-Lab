using System;

namespace Experiment_2
{
    internal class Exp2
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount(123456, "Rushikesh Anantpure", 5000);
            account1.showDetails();
            account1.withdraw(2000);
            account1.deposit(1000);
            account1.showDetails();

            Console.WriteLine("\nExecution finished. Press any key to close this window...");
            Console.ReadKey();
        }
    }
}