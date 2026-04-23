using System;

public class Invoice
{
    public void CalculateTotal()
    {
        Console.WriteLine("Calculating total...");
    }
}

public class InvoicePrinter
{
    public void Print(Invoice invoice)
    {
        Console.WriteLine("Printing invoice...");
    }
}

public class InvoiceRepository
{
    public void Save(Invoice invoice)
    {
        Console.WriteLine("Saving invoice...");
    }
}