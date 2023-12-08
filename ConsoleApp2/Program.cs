

// Program.cs
/// <summary>
/// Represents the main namespace for the console application.
/// </summary>

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)

        {
            string jsonFilePath = "./data/clients.json";


            // Créez une instance de la classe ClientList
            ClientList clientList = new ClientList();

            // Importez les données des clients depuis le fichier JSON
            clientList.ImportFromJson(jsonFilePath);



            // Affichez le menu principal
            Console.WriteLine("Bienvenue dans le système de gestion de compte bancaire");

            // Se connecter
            Client client = new Client(clientList.Clients);
            // Se connecter
            while (!client.Login())
            {
                Console.WriteLine("Veuillez réessayer");
            }



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
