using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NewYear;

namespace ATS
{
    public delegate void GenerateCallEngineHandler(object sender, GenerateCallEventArgs e);
    public class ATS
    {
        
        public event GenerateCallEngineHandler AcceptCall;
        public ATS()
        {
            GenerateNumbers();
        }

        public static readonly List<Client> Clients = new List<Client>();
        public static readonly List<Call> Calls = new List<Call>();
        private static readonly int[] ArchiveNumbers = new int[90000];

       
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

        public static void AddContract(string[] names)
        {
            var firstName = names[0];
            var lastName = names[1];
            var usingPorts = Clients.Count;
            var newClient = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Port = new Port(usingPorts),
                Number = ArchiveNumbers[usingPorts],
                Tariff = new Tariff(StatusTariff.Default)
            };
            Clients.Add(newClient);
        }

        public void ReadContracts(string path)
        {
            string text = InfoFromFile.GetTextFile(path);
            string[] clients = text.Split('\n');
            foreach (var clientName in clients.Select(clientNames => clientNames.Split('|')))
            {
                AddContract(clientName);
            }
        }

        public void ReadEvents(string path)
        {
            string[] calls = InfoFromFile.GetTextFile(path).Split('\n');
            foreach (var call in calls)
            {
                string[] stringPorts = call.Split('|');
                int port0 = Int32.Parse(stringPorts[0]);
                int port1 = Int32.Parse(stringPorts[1]);
                GenerateCallEventArgs e = new GenerateCallEventArgs(port0,port1);
                AcceptCall += OnAcceptCall(e);
            }
        }
        protected virtual void OnAcceptCall(GenerateCallEventArgs e)
        {
            if (AcceptCall != null)
            {
                AcceptCall(this, e);
            }

        }

        public void GenerateCall(int port0, int port1)
        {
            var handler = AcceptCall;
            if (handler == null) return;
            if (Clients[port0].Port.Status == StatusPort.On ||
                Clients[port1].Port.Status == StatusPort.On)
            {
                Random rnd = new Random();
                int duration = rnd.Next(1, 10);
                Calls.Add(new Call
                {
                    Port0 = Clients[port0].Port,
                    Port1 = Clients[port1].Port,
                    Duration = duration
                });
                Clients[port0].Port.Status = StatusPort.Busy;
                Clients[port1].Port.Status = StatusPort.Busy;
            }
            else
            {
                Console.WriteLine("Call {0} - {1} is impossible", Clients[port0].Show(), Clients[port1].Show());
            }
        }
        public void InformationAtsToFile()
        {
            string infoBase = Clients.Aggregate("Clients in ATS:\r\n",
                (current, client) => current + client.Show() + "\r\n");
            infoBase = infoBase + "-----------------------------------------------\r\n";
            infoBase = infoBase + "All calls in ATS:\r\n";
            infoBase = Calls.Aggregate(infoBase, (current, call) => current + call.ToString() + "\r\n");
            File.WriteAllText(@"d:\epam\Tasks\l1\l1\ATS\Files\infoBase.txt", infoBase);
            
        }
    }
}
