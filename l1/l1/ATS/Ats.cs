using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewYear;

namespace ATS
{
    public class ATS
    {
        public ATS()
        {
            GenerateNumbers();
        }
        private static readonly List<Client> Clients = new List<Client>();
        private readonly List<Call> _calls = new List<Call>();
        private static readonly int[] ArchiveNumbers = new int[90000];
        public static List<Client> ListClients
        {
            get { return Clients; }
        }
        public List<Call> Calls
        {
            get { return _calls; }
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void AddCall(Call call)
        {
            Calls.Add(call);
        }

        public static Client SearchClient(Port port)
        {
            var varClient = new Client();
            foreach (var client in Clients.Where(client => client.Port == port))
            {
                varClient = client;
            }
            return varClient;
        }
        public void GenerateNumbers()
        {
            for (var i = 0; i < ArchiveNumbers.Length; i++)
            {
                ArchiveNumbers[i] = i + 10000;
            }
            var random = new Random();
            for (var i = 2; i < ArchiveNumbers.Length; ++i)
            {
                var temp = ArchiveNumbers[i];
                var nextRandom = random.Next(i - 1);
                ArchiveNumbers[i] = ArchiveNumbers[nextRandom];
                ArchiveNumbers[nextRandom] = temp;
            }
        }
        public void ClientCalls(Client client)
        {
            foreach (var call in Calls.Where(call => (client.Port == call.Port1) || (client.Port == call.Port2)))
            {
                Console.WriteLine(call.ToString());
            }
        }
        public static void AddContract(string[] names)
        {
            var firstName = names[0];
            var lastName = names[1];
            var usingPorts = Clients.Count;
            var newClient = new Client
            {
                FirstName = firstName, LastName = lastName, Port = new Port(usingPorts),
                Number = ArchiveNumbers[usingPorts]
            };
            Clients.Add(newClient);
        }
        public void GenerateContract(string path)
        {
            var text = InfoFromFile.GetTextFile(path);
            var clients = text.Split('\n');
            foreach (var clientNames in clients.Select(client => client.Split('|')))
            {
                AddContract(clientNames);
            }
        }
    }
}
