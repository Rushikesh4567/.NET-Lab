using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Delegates
    delegate int Calc(int a, int b);
    delegate void Show();

    static void Main(string[] args)
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("        EXP 04 - DELEGATES & LAMBDA");
        Console.WriteLine("=========================================");

        Activity1();
        Activity2();
        Activity3();
        Activity4();
        Activity5();
        Activity6();

        Console.WriteLine("\nExecution finished. Press any key to close this window...");
        Console.ReadKey();
    }

    // ---------------- 1 ----------------
    static void Activity1()
    {
        Console.WriteLine("\n1. Calculator using Delegates");
        Console.WriteLine("---------------------------------");

        Calc add = Add;
        Calc sub = Sub;

        Console.WriteLine("Addition (10 + 5) = " + add(10, 5));
        Console.WriteLine("Subtraction (10 - 5) = " + sub(10, 5));
    }

    static int Add(int a, int b) => a + b;
    static int Sub(int a, int b) => a - b;

    // ---------------- 2 ----------------
    static void Activity2()
    {
        Console.WriteLine("\n2. Multicast Delegate Example");
        Console.WriteLine("---------------------------------");

        Show s = Method1;
        s += Method2;

        s();
    }

    static void Method1() => Console.WriteLine("Method 1 Executed");
    static void Method2() => Console.WriteLine("Method 2 Executed");

    // ---------------- 3 ----------------
    static void Activity3()
    {
        Console.WriteLine("\n3. Lambda Expressions");
        Console.WriteLine("---------------------------------");

        Calc add = (a, b) => a + b;
        Calc mul = (a, b) => a * b;

        Console.WriteLine("Addition (5 + 3) = " + add(5, 3));
        Console.WriteLine("Multiplication (5 * 3) = " + mul(5, 3));
    }

    // ---------------- 4 ----------------
    static void Activity4()
    {
        Console.WriteLine("\n4. Sort List using Lambda");
        Console.WriteLine("---------------------------------");

        List<int> numbers = new List<int> { 5, 2, 9, 1 };

        numbers.Sort((a, b) => a.CompareTo(b));

        Console.Write("Sorted List: ");
        foreach (var n in numbers)
            Console.Write(n + " ");
        Console.WriteLine();
    }

    // ---------------- 5 ----------------
    static void Activity5()
    {
        Console.WriteLine("\n5. Company Example (Delegates & Lambda)");
        Console.WriteLine("---------------------------------");

        List<Employee> list = new List<Employee>()
        {
            new Employee { Name = "A", Salary = 30000 },
            new Employee { Name = "B", Salary = 50000 },
            new Employee { Name = "C", Salary = 45000 }
        };

        var result = list.FindAll(e => e.Salary > 40000);

        Console.WriteLine("Employees with Salary > 40000:");
        foreach (var emp in result)
            Console.WriteLine(emp.Name + " - " + emp.Salary);
    }

    // ---------------- 6 ----------------
    // LINQ Queries - Language Integrated Query (used to query data easily)
    static void Activity6()
    {
        Console.WriteLine("\n6. LINQ Queries");
        Console.WriteLine("---------------------------------");

        int[] nums = { 1, 2, 3, 4, 5 };

        var result = from n in nums
                     where n > 2
                     select n;

        Console.Write("Numbers greater than 2: ");
        foreach (var i in result)
            Console.Write(i + " ");
        Console.WriteLine();
    }
}

// Employee class (for Activity 5)
class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
}