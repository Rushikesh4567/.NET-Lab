using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, string> SimpleCache = new Dictionary<string, string>();

    static void Main()
    {
        Console.WriteLine("--- Experiment 10: Logging & Caching Concept ---\n");

        Log("Program Started.");

        string data1 = GetDataWithCache("User123");
        string data2 = GetDataWithCache("User123"); 

        Log("Program Finished.");
    }

    static void Log(string message)
    {
        Console.WriteLine("[LOG - " + DateTime.Now.ToString("HH:mm:ss") + "] " + message);
    }

    static string GetDataWithCache(string key)
    {
        if (SimpleCache.ContainsKey(key))
        {
            Log("Cache HIT for key '" + key + "'. Returning saved data.");
            return SimpleCache[key];
        }
        else
        {
            Log("Cache MISS for key '" + key + "'. Processing expensive calculation...");
            
            string newData = "Extracted Data for " + key;
            
            SimpleCache[key] = newData;
            Log("Data stored in Cache for future use.");
            
            return newData;
        }
    }
}
