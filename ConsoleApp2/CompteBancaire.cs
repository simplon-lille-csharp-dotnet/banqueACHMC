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
                Console.WriteLine($"Ajout de {montant} € au compte.");  
                return true;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout d'argent : {ex.Message}");
                return false;
            }
        }

        public bool RetirerArgent(decimal montant)
        {
            try
            {
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
            }
        }

        public bool VoirSolde()
        {
            Console.WriteLine($"Solde actuel : {Solde} €");
            return true;
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