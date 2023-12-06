namespace ConsoleApp2;

internal class Program
{
    private static void Main(string[] args)
    {
        // Creating an instance of CompteBancaire
        CompteBancaire compteBancaire = new CompteBancaire();

        while (true)
        {
            Console.WriteLine("\n1. Ajouter de l'argent");
            Console.WriteLine("2. Retirer de l'argent");
            Console.WriteLine("3. Voir le solde");
            Console.WriteLine("4. Quitter");
            Console.Write("\n\tChoisissez une option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Montant à déposer : ");
                        decimal depositAmount = Convert.ToInt32(Console.ReadLine());
                        if(depositAmount <= 0)
                        {
                            Console.WriteLine("Montant insuffisant");
                        }
                        else { 
                            compteBancaire.AjouterArgent(depositAmount);
                            Console.WriteLine("\nAppuyez sur entrée pour retourner au menu");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Montant à Retirer : ");
                        decimal withdrawAmount = Convert.ToInt32(Console.ReadLine());
                        if (withdrawAmount <= 0)
                        {
                            Console.WriteLine("Montant invalide");
                        }
                        else
                        {
                            compteBancaire.RetirerArgent(withdrawAmount);
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;

                    case 3:
                        compteBancaire.VoirSolde();
                        break;

                    case 4:
                        Console.WriteLine("\n\tMerci d'avoir utilisé notre service. Au revoir!");
                        return;

                    default:
                        Console.WriteLine("\n\tOption invalide. Veuillez choisir une option valide.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n\tEntrée invalide. Veuillez entrer un nombre.");
            }
        }
    }
}
