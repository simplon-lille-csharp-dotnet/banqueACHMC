using System;
using System.Collections.Generic;
using System.Transactions;

public class NotificationDelegate
{
    public int dateYear;
    public int NombreRetraitsAutorises { get; set; }
    public int NombreAnnees { get; set; }
    public decimal TauxInteret { get; set; }
    public decimal SoldeEstime { get; set; }

    public decimal Solde { get; set; }



    public List<Transaction> TransactionList { get; } = new List<Transaction>();


    public class Transaction
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }

        public Transaction(string type, decimal amount)
        {
            Type = type;
            Amount = amount;
        }
    }

    public virtual bool AjouterArgent(decimal montant)
    {
        try
        {
            if (montant < 0)
            {
                Console.WriteLine("\nLe montant doit être positif.");
                return false;
            }

            Solde += montant;
            TransactionList.Add(new Transaction("Dépôt", montant));
            Console.WriteLine($"\nAncien solde : {Solde - montant} euros");
            Console.WriteLine($"\nNouveau solde : {Solde} euros");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\t\nErreur lors de l'ajout d'argent : {ex.Message}");
            return false;
        }
    }

};
