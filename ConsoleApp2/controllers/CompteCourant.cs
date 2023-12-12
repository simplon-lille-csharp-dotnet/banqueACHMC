using System;

namespace BanqueAcmc
{
    public class CompteCourant : CompteBancaire
    {
        public Guid newId = Guid.NewGuid();

        public CompteCourant()
        {
        }

        public override bool AjouterArgent(decimal montant)
        {
            Console.WriteLine(newId);
            if (montant > 1000)
            {
                Console.WriteLine("Montant trop élevé");
                return false;
            }
            return base.AjouterArgent(montant);
        }

        public override bool RetirerArgent(decimal montant)
        {
            if (montant > 500)
            {
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
}