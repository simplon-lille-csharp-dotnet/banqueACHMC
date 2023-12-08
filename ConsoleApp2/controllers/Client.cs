namespace ConsoleApp2
{
    public class Client : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Login()
        {

            Console.WriteLine("Entrez votre nom d'utilisateur : ");
            string username = Console.ReadLine();
            Console.WriteLine("Entrez votre mot de passe : ");
            string password = Console.ReadLine();

            if (username == "user1" && password == "password1")
            {
                Console.WriteLine("Vous êtes connecté");
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
            if (answer == "O" || answer == "o")
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        // ClientList class
        public class ClientList
        {
            private List<Client> clients = new List<Client>();

            public void AddClient(string username, string password)
            {
                clients.Add(new Client { Username = username, Password = password });
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
            public static ClientList Clients = new ClientList();
            Client client1 = new Client { Username = "user1", Password = "password1" };
            Client client2 = new Client { Username = "user2", Password = "password2" };
            Client client3 = new Client { Username = "user3", Password = "password3" };
            Client client4 = new Client { Username = "user4", Password = "password4" };

            public Client GetClient(string username)
            {
                return clients.FirstOrDefault(c => c.Username == username);
            }
        }
    }




}