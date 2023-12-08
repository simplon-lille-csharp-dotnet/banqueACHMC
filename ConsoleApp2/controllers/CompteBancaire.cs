namespace ConsoleApp2;

/// <summary>
/// Represents a bank account.
/// </summary>
public class CompteBancaire : ITransactionnel
{
    public decimal Solde { get; set; }
    private List<Transaction> TransactionList { get; } = new List<Transaction>();

    public CompteBancaire()
    {

    }

    /// <summary>
    /// Adds the specified amount of money to the account balance.
    /// </summary>
    /// <param name="montant">The amount of money to be added.</param>
    /// <returns>True if the money was successfully added, false otherwise.</returns>
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

    /// <summary>
    /// Withdraws the specified amount from the bank account.
    /// </summary>
    /// <param name="montant">The amount to withdraw.</param>
    /// <returns>True if the withdrawal is successful, otherwise false.</returns>
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

    /// <summary>
    /// Retrieves the current balance of the bank account.
    /// </summary>
    /// <returns>The current balance in euros.</returns>
    public decimal VoirSolde()
    {
        Console.WriteLine($"\t\nSolde actuel : {Solde} euros");
        

        return Solde;
    }

    /// <summary>
    /// Displays the transaction history of the bank account.
    /// </summary>
    /// <returns>True if the transaction history is displayed successfully, otherwise false.</returns>
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

