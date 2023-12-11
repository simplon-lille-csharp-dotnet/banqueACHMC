using System;

namespace ConsoleApp2
{
    /// <summary>
    /// Represents a savings account.
    /// </summary>
    /// <remarks>
    /// This class inherits from the <see cref="CompteBancaire"/> class and adds additional properties and methods specific to a savings account.
    /// </remarks>
    public class CompteEpargne : CompteBancaire
    {
        public new decimal SoldeEstime { get; set; }
        public new decimal TauxInteret { get; set; }
        public new int NombreRetraitsAutorises { get; set; }

        /// <summary>
        /// Represents a savings account.
        /// </summary>
        public CompteEpargne()
        {
            // Initialize properties in the constructor
            SoldeEstime = 0;
            TauxInteret = 0;
            NombreRetraitsAutorises = 0;
        }

        /// <summary>
        /// Calculates and updates the estimated balance of the savings account with the interest earned.
        /// </summary>
        /// <param name="solde">The current balance of the savings account.</param>
        public new void InteretEpargne(decimal solde)
        {
            if ( SoldeEstime == 0)
            {
                // Handle the null case or throw an exception based on your requirements
                // Example: throw new InvalidOperationException("SoldeEstime is not initialized.");
            }

            decimal interets = SoldeEstime * TauxInteret;
            SoldeEstime += interets;

            //Console.WriteLine($"Intérêts : {interets} €");
        }

        /// <summary>
        /// Définit le nombre de retraits autorisés pour le compte épargne.
        /// </summary>
        /// <param name="nombreRetraits">Le nombre de retraits autorisés.</param>
        public new void DefinirNombreRetraitsAutorises(int nombreRetraits)
        {
            if (nombreRetraits >= 0)
            {
                NombreRetraitsAutorises = nombreRetraits;
                Console.WriteLine($"Nombre de retraits autorisés défini à : {nombreRetraits}");
            }
            else
            {
                // Handle the case where the input is invalid (negative)
                // Example: throw new ArgumentException("Nombre de retraits autorisés ne peut pas être négatif.");
            }
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

        internal int GetNombreRetraitsAutorises()
        {
            return NombreRetraitsAutorises;
        }
    }
}
