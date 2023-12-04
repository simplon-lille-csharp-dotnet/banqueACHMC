namespace ConsoleApp2
{
    public class CompteBancaire : ITransactionnel
    {

        private decimal Solde { get; set; }
        private string? NumCompte { get; set; }
        private decimal Historique { get; set; }

        public decimal AjouterArgent(decimal montant)
        {
            throw new NotImplementedException();
        }

        public decimal RetirerArgent(decimal montant)
        {
            throw new NotImplementedException();
        }

        public decimal VoirSolde()
        {
            throw new NotImplementedException();
        }

        List<ITransactionnel> transactionList = new List<ITransactionnel>();

    }
}