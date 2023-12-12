using System;

namespace BanqueAcmc
{
    // Représente un compte épargne.
    // Cette classe hérite de la classe CompteBancaire et ajoute des propriétés et des méthodes spécifiques à un compte épargne.
    public class CompteEpargne : CompteBancaire
    {
        // Solde estimé du compte épargne.
        public new decimal SoldeEstime { get; set; }

        // Taux d'intérêt du compte épargne.
        public new decimal TauxInteret { get; set; }

        // Nombre de retraits autorisés pour le compte épargne.
        public new int NombreRetraitsAutorises { get; set; }

        // Initialise un nouveau compte épargne.
        public CompteEpargne()
        {
            // Initialise les propriétés dans le constructeur.
            SoldeEstime = 0;
            TauxInteret = 0;
            NombreRetraitsAutorises = 0;
            newId = Guid.NewGuid();
        }

        // Calcule et met à jour le solde estimé du compte épargne avec les intérêts gagnés.
        public new void InteretEpargne(decimal solde)
        {
            // Vérifie si le solde estimé n'est pas initialisé.
            if (SoldeEstime == 0)
            {
                // Gérer le cas où le solde estimé n'est pas initialisé.
                // Exemple : throw new InvalidOperationException("SoldeEstime n'est pas initialisé.");
            }

            decimal interets = SoldeEstime * TauxInteret;
            SoldeEstime += interets;

            //Console.WriteLine($"Intérêts : {interets} €");
        }

        // Définit le nombre de retraits autorisés pour le compte épargne.
        public new void DefinirNombreRetraitsAutorises(int nombreRetraits)
        {
            // Vérifie si le nombre de retraits est valide (non négatif).
            if (nombreRetraits >= 0)
            {
                NombreRetraitsAutorises = nombreRetraits;
                Console.WriteLine($"Nombre de retraits autorisés défini à : {nombreRetraits}");
            }
            else
            {
                // Gérer le cas où l'entrée n'est pas valide (négative).
                // Exemple : throw new ArgumentException("Nombre de retraits autorisés ne peut pas être négatif.");
            }
        }

        // Retire de l'argent du compte épargne.
        public override bool RetirerArgent(decimal montant)
        {
            // Vérifie s'il reste des retraits autorisés.
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

        // Retourne le nombre de retraits autorisés restants.
        internal int GetNombreRetraitsAutorises()
        {
            return NombreRetraitsAutorises;
        }
    }
}
