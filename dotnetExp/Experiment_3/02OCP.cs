using System;

public abstract class Discount
{
    public abstract double GetDiscount();
}

public class RegularCustomer : Discount
{
    public override double GetDiscount() => 10;
}

public class PremiumCustomer : Discount
{
    public override double GetDiscount() => 20;
}