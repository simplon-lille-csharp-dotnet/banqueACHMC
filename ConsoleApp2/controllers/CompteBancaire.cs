namespace ConsoleApp2;

public class CompteBancaire : ITransactionnel
{
    public decimal Solde { get; set; }
    private List<Transaction> TransactionList { get; } = new List<Transaction>();

    public CompteBancaire()
    {

    }

    public virtual bool AjouterArgent(decimal montant)
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

    public virtual bool RetirerArgent(decimal montant)
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
            Console.WriteLine($@"Vous vennez de retirer {montant} euros" + "\n");
            Console.WriteLine($@"Votre nouveau solde est de {Solde} euros" + "\n");
            Console.WriteLine("Appuyez sur Entrer pour retourner au menu");
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

    public bool VoirHistorique()
    {
        if (TransactionList.Count > 0)
        {
            Console.WriteLine("Historique des transactions :");
            foreach (var transaction in TransactionList)
            {
                Console.WriteLine(transaction);
            }
        }
        else
        {
            Console.WriteLine("Aucune transaction effectuée.");
        }
        return true;
    }

    bool ITransactionnel.VoirSolde()
    {
        Console.WriteLine($"Solde actuel : {Solde} €");
        return true;
    }
}
