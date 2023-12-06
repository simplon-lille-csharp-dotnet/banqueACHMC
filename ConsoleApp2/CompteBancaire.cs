﻿namespace ConsoleApp2;

public class CompteBancaire : ITransactionnel
{
    private decimal Solde { get; set; }
    private List<Transaction> TransactionList { get; } = new List<Transaction>();

    public CompteBancaire()
    {

    }

    public bool AjouterArgent(decimal montant)
    {
        try
        {
            Solde += montant;
            TransactionList.Add(new Transaction("Dépôt", montant));
            Console.WriteLine($"Ancien solde : {Solde - montant} €");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'ajout d'argent : {ex.Message}");
            return false;
        }
    }

        public bool RetirerArgent(decimal montant)
        {
            try
            {
                if (montant > Solde || Solde >= 0)
                {
                    Console.WriteLine("Fonds insuffisants pour effectuer le retrait.");
                    return false;
                }

            Solde -= montant;
            TransactionList.Add(new Transaction("Retrait", montant));
            return true;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erreur lors du retrait d'argent : {ex.Message}");
            return false;
        }
    }

    public decimal VoirSolde()
    {
        // Implémentez la logique pour voir le solde
        return Solde;
    }

    bool ITransactionnel.VoirSolde()
    {
        Console.WriteLine($"Solde actuel : {Solde} €");
        return true;
    }
}
