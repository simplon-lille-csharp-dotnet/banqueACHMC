namespace ConsoleApp2
{
    public class CompteBancaire : ITransactionnel
    {
        

        private decimal Solde { get; set; }
        private List<Transaction>? TransactionList { get; }

        public bool AjouterArgent(decimal montant)
        {
            try
            {
                // Implémentez la logique pour ajouter de l'argent au solde
                Solde += montant;
                TransactionList.Add(new Transaction("Dépôt", montant));
                return true; // Opération réussie
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout d'argent : {ex.Message}");
                return false; // Opération échouée
            }
        }

        public bool RetirerArgent(decimal montant)
        {
            throw new NotImplementedException();
        }

        public bool VoirSolde()
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
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Format de date personnalisé
        }

        public override string ToString()
        {
            return $"{Date} - {Type}: {Montant} €";
        }}
}