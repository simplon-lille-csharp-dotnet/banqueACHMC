namespace ConsoleApp2;

internal class Program
{
    private static void Main(string[] args)
    {
        // Creating an instance of CompteBancaire
        CompteBancaire compteBancaire = new CompteBancaire();

        while (true)
        {
            Console.WriteLine("1. Ajouter de l'argent");
            Console.WriteLine("2. Retirer de l'argent");
            Console.WriteLine("3. Voir le solde");
            Console.WriteLine("4. Quitter");
            Console.Write("Choisissez une option (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Montant à déposer : ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            compteBancaire.AjouterArgent(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Montant invalide.");
                        }
                        break;

                    case 2:
                        Console.Write("Montant à retirer : ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            compteBancaire.RetirerArgent(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Montant invalide.");
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Solde actuel : {compteBancaire.VoirSolde()}");
                        break;

                    case 4:
                        Console.WriteLine("Merci d'avoir utilisé notre service. Au revoir!");
                        return;

                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre.");
            }
        }
    }
}
