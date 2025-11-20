using System;
using Shopmate.Services;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----Welcome to ShopMate CLI-----");
        Thread.Sleep(500);
        Console.WriteLine("Buy and sell anytime, anythings, anywhere!");
        Thread.Sleep(500);
        Auth.Authinticate();
    }
}