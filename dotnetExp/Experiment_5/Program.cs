using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("      EXP 05 - ASYNC PROGRAMMING");
        Console.WriteLine("=========================================");

        Activity1_Synchronous();
        await Activity2_Asynchronous();
        await Activity3_DelayVsSleep();
        await Activity4_TaskMethod();

        Console.WriteLine("\nExecution finished. Press any key to close this window...");
        Console.ReadKey();
    }

    // ---------------- 1 ----------------
    static void Activity1_Synchronous()
    {
        Console.WriteLine("\n1. Synchronous Execution");
        Console.WriteLine("---------------------------------");

        Task1_Sync();
        Task2_Sync();
    }

    static void Task1_Sync()
    {
        Console.WriteLine("Task 1 Started...");
        Thread.Sleep(1000); // blocks thread
        Console.WriteLine("Task 1 Completed");
    }

    static void Task2_Sync()
    {
        Console.WriteLine("Task 2 Started...");
        Thread.Sleep(1000);
        Console.WriteLine("Task 2 Completed");
    }

    // ---------------- 2 ----------------
    static async Task Activity2_Asynchronous()
    {
        Console.WriteLine("\n2. Asynchronous Execution");
        Console.WriteLine("---------------------------------");

        Task t1 = Task1_Async();
        Task t2 = Task2_Async();

        await Task.WhenAll(t1, t2);
    }

    static async Task Task1_Async()
    {
        Console.WriteLine("Task 1 Started...");
        await Task.Delay(1000);
        Console.WriteLine("Task 1 Completed");
    }

    static async Task Task2_Async()
    {
        Console.WriteLine("Task 2 Started...");
        await Task.Delay(1000);
        Console.WriteLine("Task 2 Completed");
    }

    // ---------------- 3 ----------------
    static async Task Activity3_DelayVsSleep()
    {
        Console.WriteLine("\n3. Thread.Sleep vs Task.Delay");
        Console.WriteLine("---------------------------------");

        Console.WriteLine("Using Thread.Sleep (Blocking)...");
        Thread.Sleep(1000);
        Console.WriteLine("Done with Sleep");

        Console.WriteLine("Using Task.Delay (Non-Blocking)...");
        await Task.Delay(1000);
        Console.WriteLine("Done with Delay");
    }

    // ---------------- 4 ----------------
    static async Task Activity4_TaskMethod()
    {
        Console.WriteLine("\n4. Method Returning Task");
        Console.WriteLine("---------------------------------");

        int result = await CalculateAsync();
        Console.WriteLine("Result: " + result);
    }

    static async Task<int> CalculateAsync()
    {
        await Task.Delay(1000);
        return 10 + 20;
    }
}