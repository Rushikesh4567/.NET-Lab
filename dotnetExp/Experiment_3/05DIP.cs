using System;

public interface IMessageService
{
    void SendMessage();
}

public class EmailService : IMessageService
{
    public void SendMessage()
    {
        Console.WriteLine("Email Sent");
    }
}

public class SMSService : IMessageService
{
    public void SendMessage()
    {
        Console.WriteLine("SMS Sent");
    }
}

public class Notification
{
    private IMessageService service;

    public Notification(IMessageService service)
    {
        this.service = service;
    }

    public void Notify()
    {
        Console.WriteLine("Sending Notification...");
        service.SendMessage();
    }
}