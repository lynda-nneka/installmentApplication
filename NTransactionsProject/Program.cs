// See https://aka.ms/new-console-template for more information
using System;
using NTransactionsProject;

public static class Program
{
    public static void Main(string[] args)
    {
        var transactionsManager = new TransactionsManager();
        transactionsManager.Start();
        Console.ReadKey();
    }
}