// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
using System.Reflection.Metadata;

public class CompteCourant : CompteBancaire
{
    
    public CompteCourant()
    {
            
    }

    decimal montant { get; set; }
    public override bool AjouterArgent(decimal montant)
    { 
        if (montant > 1000)
        {
            //throw new InvalidOperationException("Montant trop élevé");
            Console.WriteLine("Montant trop élevé");
            return false;

        }
      return base.AjouterArgent(montant);
    }

    public override bool RetirerArgent(decimal montant)
    {
        if (montant > 500)
        {
            //throw new InvalidOperationException("Montant trop élevé");
            Console.WriteLine("Montant trop élevé");
            return false;
        }
        return base.RetirerArgent(montant);
    }

    public void InteretCourant()
    {
        throw new System.NotImplementedException();
    }

     
}
