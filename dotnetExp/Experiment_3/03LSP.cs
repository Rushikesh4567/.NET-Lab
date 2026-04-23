using System;

public interface IFlyable
{
    void Fly();
}

public class Sparrow : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Sparrow flying");
    }
}

public class Ostrich
{
    public void Run()
    {
        Console.WriteLine("Ostrich running");
    }
}