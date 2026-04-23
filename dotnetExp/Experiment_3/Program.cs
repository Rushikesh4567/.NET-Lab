using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---- SOLID Principles Demo ----");

        // SRP
        Console.WriteLine("\nSRP - Single Responsibility Principle");
        Invoice invoice = new Invoice();
        invoice.CalculateTotal();
        new InvoicePrinter().Print(invoice);
        new InvoiceRepository().Save(invoice);

        // OCP
        Console.WriteLine("\nOCP - Open/Closed Principle");
        Discount d1 = new RegularCustomer();
        Discount d2 = new PremiumCustomer();
        Console.WriteLine($"Regular Customer Discount: {d1.GetDiscount()}%");
        Console.WriteLine($"Premium Customer Discount: {d2.GetDiscount()}%");

        // LSP
        Console.WriteLine("\nLSP - Liskov Substitution Principle");
        IFlyable bird = new Sparrow();
        bird.Fly();
        new Ostrich().Run();

        // ISP
        Console.WriteLine("\nISP - Interface Segregation Principle");
        Human h = new Human();
        h.Work();
        h.Eat();
        new Robot().Work();

        // DIP
        Console.WriteLine("\nDIP - Dependency Inversion Principle");
        IMessageService email = new EmailService();
        Notification n1 = new Notification(email);
        n1.Notify();

        IMessageService sms = new SMSService();
        Notification n2 = new Notification(sms);
        n2.Notify();

        Console.WriteLine("\nExecution finished. Press any key to close this window...");
        Console.ReadKey();
    }
}