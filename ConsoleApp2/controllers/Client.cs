using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConsoleApp2
{


    public class Client : IUser
    {
        // Injectez la liste des clients depuis ClientList
        private List<Client> clients;

        public Client(List<Client> clients)
        {
            this.clients = clients;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

       


        public bool Login()
        {
            Console.WriteLine("Entrez votre nom d'utilisateur : ");
            string username = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe : ");
            string password = Console.ReadLine();

            Client client = clients.FirstOrDefault(c => c.Username == username && c.Password == password);

            if (client != null)
            {
                Console.WriteLine($"Vous êtes connecté en tant que {client.FirstName} {client.LastName}");
                return true;
            }
            else
            {
                Console.WriteLine("Nom d'utilisateur ou mot de passe incorrect");
                return false;
            }
        }

        public bool Logout()
        {
            Console.Clear();
            Console.WriteLine("Voulez-vous vraiment vous déconnecter ? (O/N)");
            string answer = Console.ReadLine();
            return (answer == "O" || answer == "o");
        }
    }

    // ClientList class
    public class ClientList
    {
        private List<Client> clients = new List<Client>();

        public List<Client> Clients
        {
            get { return clients; }
        }

        public void AddClient(string username, string password, string firstName, string lastName, string email)
        {
            clients.Add(new Client(clients) { Username = username, Password = password, FirstName = firstName, LastName = lastName, Email = email });
        }

        public bool RemoveClient(string username)
        {
            var client = clients.FirstOrDefault(c => c.Username == username);
            if (client != null)
            {
                clients.Remove(client);
                return true;
            }
            return false;
        }

        public void ExportToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(clients, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Les données des clients ont été exportées vers {filePath}");
        }

        public Client GetClient(string username)
        {
            return clients.FirstOrDefault(c => c.Username == username);
        }

        public void ImportFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                clients = JsonConvert.DeserializeObject<List<Client>>(json);
                Console.WriteLine($"Les données des clients ont été importées depuis {filePath}");
            }
            else
            {
                Console.WriteLine($"Le fichier {filePath} n'existe pas.");
            }
        }
    }
}
