// CompteBancaire.cs

using System;
using System.Collections.Generic;

namespace BanqueAcmc
{
    public class CompteBancaire : ITransactionnel
    {
        public Guid newId;

        private int dateYear;
        public int NombreRetraitsAutorises { get; set; }
        public int NombreAnnees { get; set; }
        public decimal SoldeEstime { get; set; }
        public decimal TauxInteret { get; set; }
        public decimal Solde { get; set; }
        public List<Transaction> TransactionList { get; } = new List<Transaction>();

        public CompteBancaire()
        {
        }

        internal virtual decimal VoirSolde()
        {
            Console.WriteLine($"\t\nSolde actuel : {Solde} euros");
            return Solde;
        }

        internal virtual bool VoirHistorique()
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

        public virtual bool RetirerArgent(decimal montant)
        {
            if (montant > Solde)
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
            Console.WriteLine($@"Vous venez de retirer {montant} euros" + "\n");
            Console.WriteLine($@"Votre nouveau solde est de {Solde} euros" + "\n");
            Console.WriteLine("Appuyez sur Entrer pour retourner au menu");
            return true;
        }

        bool ITransactionnel.VoirSolde()
        {
            Console.WriteLine($"Solde actuel : {Solde} €");
            return true;
        }

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

                if (annee % intervalleAnnees != 0)
                {
                    continue;
                }

                Console.WriteLine($"Année {dateYear} : {SoldeEstime} €");
            }
        }

        public void InteretEpargne(decimal solde)
        {
            SoldeEstime = solde;
            decimal interets = SoldeEstime * TauxInteret;
            SoldeEstime += interets;
        }

        public void DefinirNombreRetraitsAutorises(int nombreRetraits)
        {
            NombreRetraitsAutorises = nombreRetraits;
            Console.WriteLine($"Nombre de retraits autorisés défini à : {nombreRetraits}");
        }

        bool ITransactionnel.VoirHistorique()
        {
            throw new NotImplementedException();
        }
    }
}
