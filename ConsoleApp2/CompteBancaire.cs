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
<<<<<<< HEAD
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
=======
                if (montant > Solde)
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
>>>>>>> 5e2708a8d5abd967eebf64f5c66fc636ad9cb0ff
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

<<<<<<< HEAD
    public class Transaction
=======
     public class Transaction
>>>>>>> 5e2708a8d5abd967eebf64f5c66fc636ad9cb0ff
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
