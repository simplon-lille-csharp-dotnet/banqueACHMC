
namespace ConsoleApp2;

public class CompteEpargne : CompteBancaire
{
    private int dateYear;

    private int NombreRetraitsAutorises { get; set; }


    public int NombreAnnees { get; set; }
    public decimal SoldeEstime { get; set; }
    public decimal TauxInteret { get; set; }

    public CompteEpargne(decimal tauxInteret, int nombreRetraitsAutorises)
    {


        TauxInteret = tauxInteret;
        NombreRetraitsAutorises = nombreRetraitsAutorises;
    }

    public void InteretEpargne(decimal solde)
    {
        SoldeEstime = solde;
        decimal interets = SoldeEstime * TauxInteret;
        SoldeEstime += interets;

        //Console.WriteLine($"Intérêts : {interets} €");
    }

    /// <summary>
    /// dsfsdfsdfdsf
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

    internal int getNombreRetraitsAutorises()
    {
        return NombreRetraitsAutorises;
    }
}

