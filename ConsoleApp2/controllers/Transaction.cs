namespace BanqueAcmc
{
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
