﻿// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
using System.Reflection.Metadata;

internal class CompteCourant : CompteBancaire
{

  public decimal montant { get; set; }
    public virtual bool AjouterArgent(decimal montant)
    { 
        if (montant > 1000)
        {
            //throw new InvalidOperationException("Montant trop élevé");
            Console.WriteLine("Montant trop élevé");
            return false;
         
        }
        return true;
    
    }

    public override bool RetirerArgent(decimal montant)
    {
        if (montant > 500)
        {
            //throw new InvalidOperationException("Montant trop élevé");
            Console.WriteLine("Montant trop élevé");
            return false;
        }
        return true;
    }

    public void InteretCourant()
    {
        throw new System.NotImplementedException();
    }
}
