namespace ConsoleApp2;

/// <summary>
/// Represents a bank account.
/// </summary>
public class CompteBancaire : ITransactionnel
{
    /// <summary>
    /// Represents the year of a date.
    /// </summary>
    private int dateYear;

    /// <summary>
    /// Gets or sets the number of authorized withdrawals.
    /// </summary>
    public int NombreRetraitsAutorises { get; set; }


    /// <summary>
    /// Gets or sets the number of years.
    /// </summary>
    public int NombreAnnees { get; set; }
    /// <summary>
    /// Gets or sets the estimated balance of the savings account.
    /// </summary>
    public decimal SoldeEstime { get; set; }
    /// <summary>
    /// Gets or sets the interest rate for the savings account.
    /// </summary>
    public decimal TauxInteret { get; set; }

    /// <summary>
    /// Represents a savings account.
    /// 
    /// </summary>
    /// <param name="tauxInteret">The interest rate for the savings account.</param>
    /// <param name="nombreRetraitsAutorises">The number of allowed withdrawals for the savings account.</param>
    public decimal Solde { get; set; }
    public List<Transaction> TransactionList { get; } = new List<Transaction>();

    public CompteBancaire()
    {

    }

    /// <summary>
    /// Adds the specified amount of money to the account balance.
    /// </summary>
    /// <param name="montant">The amount of money to be added.</param>
    /// <returns>True if the money was successfully added, false otherwise.</returns>
    /// 
    public virtual bool AjouterArgent(decimal montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Le montant doit être positif.");
            return false;
        }

        if (montant != Math.Round(montant, 2))
        {
            Console.WriteLine("Le montant doit avoir au maximum 2 décimales.");
            return false;
        }


        Solde += montant;
        TransactionList.Add(new Transaction("Dépôt", montant));
        Console.WriteLine($"\nAncien solde : {Solde - montant} euros");
        Console.WriteLine($"\nNouveau solde : {Solde} euros");
        return true;
    }

    /// <summary>
    /// Withdraws the specified amount from the bank account.
    /// </summary>
    /// <param name="montant">The amount to withdraw.</param>
    /// <returns>True if the withdrawal is successful, otherwise false.</returns>
    /// 
    public virtual bool RetirerArgent(decimal montant)
    {

        if (montant > Solde )
        {
            Console.WriteLine("\t\nFonds insuffisants pour effectuer le retrait.");
            return false;
        }
        else if (montant <= 0)
        {
            Console.WriteLine("Le montant doit être positif.");
            return false;
        }
        else if (montant != Math.Round(montant, 2))
        {
            Console.WriteLine("Le montant doit avoir au maximum 2 décimales.");
            return false;
        }      
        else if (montant > Solde)
        {
            Console.WriteLine("Vous n'avez pas assez d'argent sur votre compte.");
            return false;
        }
     
     

        Solde -= montant;
        TransactionList.Add(new Transaction("Retrait", montant));
        Console.WriteLine($@"Vous vennez de retirer {montant} euros" + "\n");
        Console.WriteLine($@"Votre nouveau solde est de {Solde} euros" + "\n");
        Console.WriteLine("Appuyez sur Entrer pour retourner au menu");
        return true;


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

    /// <summary>
    /// Affiche les prévisions pour les années spécifiées avec un intervalle spécifié
    /// </summary>
    /// <param name="nombreAnnees"></param>
    /// <param name="intervalleAnnees"></param>
    public void VoirPrevisions(int nombreAnnees, int intervalleAnnees)
    {
        Console.WriteLine($"Prévisions pour les {nombreAnnees} prochaines années avec un intervalle de {intervalleAnnees} ans:");
        dateYear = DateTime.Now.Year;

        Console.WriteLine($"Année de début : {dateYear}");
        SoldeEstime = Solde;
        for (int annee = 1; annee <= nombreAnnees; annee++)
        {
            InteretEpargne(SoldeEstime);
            dateYear++;

            // Vérifiez si l'année est un multiple de l'intervalle spécifié
            if (annee % intervalleAnnees != 0)
            {
                continue;
            }

            Console.WriteLine($"Année {dateYear} : {SoldeEstime} €");


        }
    }

    /// <summary>
    /// Calculates and updates the estimated balance of the savings account with the interest earned.
    /// </summary>
    /// <param name="solde">The current balance of the savings account.</param>
    public void InteretEpargne(decimal solde)
    {
        SoldeEstime = solde;
        decimal interets = SoldeEstime * TauxInteret;
        SoldeEstime += interets;

        //Console.WriteLine($"Intérêts : {interets} €");
    }

    /// <summary>
    /// Définit le nombre de retraits autorisés pour le compte épargne.
    /// </summary>
    /// <param name="nombreRetraits">Le nombre de retraits autorisés.</param>
    public void DefinirNombreRetraitsAutorises(int nombreRetraits)
    {
        NombreRetraitsAutorises = nombreRetraits;
        Console.WriteLine($"Nombre de retraits autorisés défini à : {nombreRetraits}");
    }
}

