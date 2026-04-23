using System;

public class SimpleAPI
{
    public string GetProductData(int productId)
    {
        Console.WriteLine("[API RECEIVED] GET request for Product ID: " + productId);
        
        if (productId == 101)
        {
            return "{ \"Status\": 200, \"Data\": \"Laptop\" }";
        }
        else
        {
            return "{ \"Status\": 404, \"Error\": \"Not Found\" }";
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Experiment 9: Web API Concept Simulator ---");
        
        SimpleAPI api = new SimpleAPI();

        Console.WriteLine("Calling API for ID 101...");
        string response1 = api.GetProductData(101);
        Console.WriteLine("Response: " + response1 + "\n");

        Console.WriteLine("Calling API for ID 999...");
        string response2 = api.GetProductData(999);
        Console.WriteLine("Response: " + response2);
    }
}
