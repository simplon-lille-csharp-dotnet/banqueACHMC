namespace ConsoleApp2;

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

    public bool RetirerArgent(decimal montant)
    {
        try
        {
            if (montant > Solde)
            {
                Console.WriteLine("\t\nFonds insuffisants pour effectuer le retrait.");
                return false;
            }

            Solde -= montant;
            TransactionList.Add(new Transaction("Retrait", montant));
            return true;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\t\nErreur lors du retrait d'argent : {ex.Message}");
            return false;
        }
    }

    public decimal VoirSolde()
    {
        Console.WriteLine($"\t\nSolde actuel : {Solde} euros");
        return Solde;
    }

    bool ITransactionnel.VoirSolde()
    {
        Console.WriteLine($"Solde actuel : {Solde} €");
        return true;
    }
}
