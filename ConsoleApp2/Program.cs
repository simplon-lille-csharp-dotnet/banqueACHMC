// See https://aka.ms/new-console-template for more information
using ConsoleApp2;

internal class Program
{
   private static void Main(string[] args)
    {
        // Création d'une liste d'interfaces ITransactionnel
        List<ITransactionnel> transactionList = new List<ITransactionnel>();

        // Ajout d'une instance de CompteBancaire à la liste
        transactionList.Add(new CompteBancaire());




    }
}