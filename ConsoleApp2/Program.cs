using System.Globalization;

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
                        if (depositAmount <= 0)
                        {
                            Console.WriteLine("Montant insuffisant");
                        }
                        else
                        {
                            compteBancaire.AjouterArgent(depositAmount);
                            Console.WriteLine("\nAppuyez sur entrée pour retourner au menu");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Montant à Retirer : ");

                        string userInput = Console.ReadLine();

                        if (decimal.TryParse(userInput, out decimal withdrawAmount) && withdrawAmount > 0 && CountDecimalPlaces(userInput) <= 2)
                        {
                            //Console.WriteLine($"La saisie utilisateur : '{withdrawAmount}'");

                            if (compteBancaire.Solde >= withdrawAmount)
                            {
                                compteBancaire.RetirerArgent(withdrawAmount);
                                Console.WriteLine($"Retrait de {withdrawAmount} euros effectué avec succès.");
                            }
                            else
                            {
                                Console.WriteLine("Solde insuffisant pour effectuer le retrait.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Montant invalide. Veuillez entrer un nombre entier ou décimal avec au plus deux chiffres après la virgule et supérieur à zéro.");
                        }

                        Console.ReadLine();
                        Console.Clear();
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

    private static decimal tryParse(string? v)
    {
        throw new NotImplementedException();
    }
    private static int CountDecimalPlaces(string value)
    {
        int decimalPlaces = 0;
        int decimalPointIndex = value.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        if (decimalPointIndex >= 0)
        {
            decimalPlaces = value.Length - decimalPointIndex - 1;
        }

        return decimalPlaces;
    }
}
