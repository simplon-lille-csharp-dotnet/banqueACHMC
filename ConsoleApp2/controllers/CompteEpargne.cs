
namespace ConsoleApp2;

/// <summary>
/// Represents a savings account.
/// </summary>
/// <remarks>
/// This class inherits from the <see cref="CompteBancaire"/> class and adds additional properties and methods specific to a savings account.
/// </remarks>
public class CompteEpargne : CompteBancaire
{
    /// <summary>
    /// Represents the year of a date.
    /// </summary>
    private int dateYear;

    /// <summary>
    /// Gets or sets the number of authorized withdrawals.
    /// </summary>
    private int NombreRetraitsAutorises { get; set; }

    public decimal tauxInteret;
    public int nombreRetraitsAutorises;


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
<<<<<<< HEAD
=======
    public CompteEpargne()
    {
     
    }
>>>>>>> 4164001c224d835e0e3f013bf6c7f8643a11d0b1

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
    /// Définit le nombre de retraits autorisés pour le compte épargne.
    /// </summary>
    /// <param name="nombreRetraits">Le nombre de retraits autorisés.</param>
    public void DefinirNombreRetraitsAutorises(int nombreRetraits)
    {
        NombreRetraitsAutorises = nombreRetraits;
        Console.WriteLine($"Nombre de retraits autorisés défini à : {nombreRetraits}");
    }
    public override bool RetirerArgent(decimal montant)
    {
        if (NombreRetraitsAutorises > 0)
        {
            NombreRetraitsAutorises--;
            return base.RetirerArgent(montant);
        }
        else
        {
            Console.WriteLine("Nombre de retraits autorisés dépassé.");
            return false;
        }
    }

    /// <summary>
    /// Gets the number of authorized withdrawals.
    /// </summary>
    /// <returns>The number of authorized withdrawals.</returns>
    internal int GetNombreRetraitsAutorises()
    {
        return NombreRetraitsAutorises;
    }
}

