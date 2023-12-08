
namespace ConsoleApp2;

/// <summary>
/// Represents a savings account.
/// </summary>
/// <remarks>
/// This class inherits from the <see cref="CompteBancaire"/> class and adds additional properties and methods specific to a savings account.
/// </remarks>
public class CompteEpargne : CompteBancaire
{
   

 

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

