using System;

namespace Experiment_1
{
    internal class Exp1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number 1 : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number 2 : ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Addition     : " + (num1 + num2));
            Console.WriteLine("Substraction : " + (num1 - num2));
            Console.WriteLine("Division     : " + (num1 / num2));
            Console.WriteLine("Multiplication : " + (num1 * num2));
            Console.WriteLine("Modulus      : " + (num1 % num2));
        }
    }
}