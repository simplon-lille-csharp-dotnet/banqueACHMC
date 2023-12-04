// See https://aka.ms/new-console-template for more information
using ConsoleApp2;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ITransactionnel> transactionList = new List<ITransactionnel>();

        transactionList.Add(new CompteBancaire());
        var compteCourant = new CompteCourant();

        transactionList.Add(compteCourant);
    }
}