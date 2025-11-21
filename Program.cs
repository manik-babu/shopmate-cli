using System;
using Shopmate.Services;
using Shopmate.Models;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"\tShopMate CLI");
        Console.WriteLine("---------------------------------");
        Thread.Sleep(500);
        Console.WriteLine("Buy and sell anytime, anythings, anywhere!");
        Thread.Sleep(500);
        Users.Add("Md Manik", "manik", "1234");
        Auth.Authinticate();
    }
}