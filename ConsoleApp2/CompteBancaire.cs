namespace ConsoleApp2
{
    public class CompteBancaire : ITransactionnel
    {
        int Solde { get; set; }
        int NumCompte { get; set; }
        int Historique { get; set; }

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
    }
}