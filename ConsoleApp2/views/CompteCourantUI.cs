using System;

namespace BanqueAcmc
{
    public class CompteCourantUI : Program, ICompteCourantUI
    {
        private CompteCourant compteCourant;

        public CompteCourantUI(CompteCourant compteCourant)
        {
            this.compteCourant = compteCourant;
        }

        public void AfficherMenuCompteCourant()
        {
            while (true)
            {
                Console.WriteLine("\n1. Ajouter de l'argent");
                Console.WriteLine("2. Retirer de l'argent");
                Console.WriteLine("3. Voir le solde");
                Console.WriteLine("4. Voir les prévisions");
                Console.WriteLine("5. Définir le nombre de retraits autorisés");
                Console.WriteLine("6. Voir l'historique");
                Console.WriteLine("7. Retourner au menu principal");
                Console.WriteLine("8. Quitter");

                Console.Write("\n\tChoisissez une option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Montant à déposer : ");
                            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                            compteCourant.AjouterArgent(depositAmount);
                            Console.WriteLine("\nAppuyez sur entrée pour retourner au menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 2:
                            Console.Clear();
                            Console.Write("Montant à Retirer : ");
                            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                            compteCourant.RetirerArgent(withdrawAmount);
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 3:
                            compteCourant.VoirSolde();
                            break;

                        case 4:
                            Console.Clear();
                            Console.Write("Nombre d'années : ");
                            int nombreAnnees = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Intervalle d'années : ");
                            int intervalleAnnees = Convert.ToInt32(Console.ReadLine());
                            compteCourant.VoirPrevisions(nombreAnnees, intervalleAnnees);
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 5:
                            Console.Clear();
                            Console.Write("Nombre de retraits autorisés : ");
                            int nombreRetraits = Convert.ToInt32(Console.ReadLine());
                            compteCourant.DefinirNombreRetraitsAutorises(nombreRetraits);
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 6:
                            Console.Clear();
                            compteCourant.VoirHistorique();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 7:
                            Program.MenuMain();
                            break;

                        case 8:
                            Console.WriteLine("\n\tMerci d'avoir utilisé notre service. Au revoir!");
                            break;

                        default:
                            Console.WriteLine("\n\tOption invalide. Veuillez choisir une option valide.");
                            break;
                    }
                }
            }
        }
    }
}