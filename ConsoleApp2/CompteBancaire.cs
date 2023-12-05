using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class CompteBancaire : ITransactionnel
    {
        private decimal Solde { get; set; }
        private List<Transaction> TransactionList { get; } = new List<Transaction>();

        public bool AjouterArgent(decimal montant)
        {
            try
            {
                // Implémentez la logique pour ajouter de l'argent au solde
                Solde += montant;
                TransactionList.Add(new Transaction("Dépôt", montant));
                return true; // Opération réussie
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout d'argent : {ex.Message}");
                return false; // Opération échouée
            }
        }

        public bool RetirerArgent(decimal montant)
        {
            try
            {
                // Implémentez la logique pour retirer de l'argent du solde
                if (montant <= Solde)
                {
                    Solde -= montant;
                    TransactionList.Add(new Transaction("Retrait", montant));
                    return true; // Opération réussie
                }
                else
                {
                    Console.WriteLine("Solde insuffisant pour effectuer le retrait.");
                    return false; // Opération échouée
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du retrait d'argent : {ex.Message}");
                return false; // Opération échouée
            }
        }

        public decimal VoirSolde()
        {
            // Implémentez la logique pour voir le solde
            return Solde;
        }

        bool ITransactionnel.VoirSolde()
        {
            throw new NotImplementedException();
        }
    }

    public class Transaction
    {
        public string Type { get; }
        public decimal Montant { get; }
        public string Date { get; }

        public Transaction(string type, decimal montant)
        {
            Type = type;
            Montant = montant;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override string ToString()
        {
            return $"{Date} - {Type}: {Montant} €";
        }
    }
}
