

// Program.cs

using System.Security.Cryptography.X509Certificates;

namespace BanqueAcmc
{
    public class Program
    {


        // Créez un compte épargne
        static CompteEpargne compteEpargne = new CompteEpargne();

        // Créez un compte courant
        static CompteCourant compteCourant = new CompteCourant();
        private static void Main(string[] args)

        {
            string jsonFilePath = Path.Combine("data", "clients.json");

            Console.WriteLine(jsonFilePath);


            // Créez une instance de la classe ClientList
            ClientList clientList = new ClientList();

            // Importez les données des clients depuis le fichier JSON
            clientList.ImportFromJson(jsonFilePath);

            

            // Affichez le menu principal
            Console.WriteLine("\t\t\nBienvenue dans le système de gestion de compte bancaire");

            // Se connecter
            Client client = new Client(clientList.Clients);
            // Se connecter
            while (!client.Login())
            {
                Console.WriteLine("\n\tVeuillez réessayer");
            }


            MenuMain();
            
        }
        public static void MenuMain()
        {
            // Affichez les options de compte
            Console.WriteLine("\nChoisissez le type de compte:");
            Console.WriteLine("\n1. Compte Épargne");
            Console.WriteLine("2. Compte Courant");

            Console.Write("\n\tVotre choix : ");

            if (int.TryParse(Console.ReadLine(), out int choixCompte))
            {
                //Choix du programme a executer
                switch (choixCompte)
                {
                    case 1:
                        // Créez un objet CompteEpargneUI
                        CompteEpargneUI compteEpargneUI = new CompteEpargneUI(compteEpargne);
                        // Affichez le menu pour le compte bancaire choisi
                        compteEpargneUI.AfficherMenuCompteEpargne();
                        break;

                    case 2:
                        // Créez un objet CompteEpargneUI
                        CompteCourantUI compteCourantUI = new CompteCourantUI(compteCourant);
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
