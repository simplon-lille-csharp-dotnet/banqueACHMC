

// Program.cs
namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Affichez les options de compte
            Console.WriteLine("Choisissez le type de compte:");
            Console.WriteLine("1. Compte Bancaire");
            Console.WriteLine("2. Compte Épargne");
            Console.WriteLine("3. Compte Courant");
            Console.Write("Votre choix : ");

            if (int.TryParse(Console.ReadLine(), out int choixCompte))
            {
                //Choix du programme a executer
                switch (choixCompte)
                {
                    case 1:
                        // Créez un compte bancaire
                        CompteBancaire compteBancaire = new CompteBancaire();
                        // Créez un objet CompteBancaireUI
                        CompteBancaireUI compteBancaireUI = new CompteBancaireUI(compteBancaire);
                        // Affichez le menu pour le compte bancaire choisi
                        compteBancaireUI.AfficherMenu();
                        break;

                    case 2:
                        // Créez un compte épargne
                        CompteEpargne compteEpargne = new CompteEpargne();
                        // Créez un objet CompteEpargneUI
                        CompteEpargneUI compteEpargneUI = new CompteEpargneUI
                        (compteEpargne);
                        // Affichez le menu pour le compte bancaire choisi
                        compteEpargneUI.AfficherMenuCompteEpargne();
                        break;

                    case 3:
                        // Créez un compte épargne
                        CompteCourant compteCourant = new CompteCourant();
                        // Créez un objet CompteEpargneUI
                        CompteCourantUI compteCourantUI = new CompteCourantUI();
                        // Affichez le menu pour le compte bancaire choisi
                        compteCourantUI.AfficherMenuCompteCourant();
                        break;
                    default:
                        break;





                }
            }


        }
    }
}
