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
    

    public class ATS
    {
        private const string OutputFile = @"d:\epam\Tasks\l1\l1\ATS\Files\infoBase.txt";
        private const string InputFile = @"d:\epam\Tasks\l1\l1\ATS\Files\Contract1.txt";
        public delegate void GenerateCallDelegate(int port0, int port1);
        public event GenerateCallDelegate GenerateCallEvent;
        readonly Random _rnd = new Random();

        public ATS()
        {
            MethodsForFiles.ReadContracts(InputFile);
            GenerateNumbers();
        }

        public static readonly List<Client> Clients = new List<Client>();
        public static readonly List<Call> Calls = new List<Call>();
        public static readonly int[] ArchiveNumbers = new int[90000];

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

        public void ReadEvents(string path)
        {
            GenerateCallEvent += GenerateCall;
            string[] calls = InfoFromFile.GetTextFile(path).Split('\n');
            foreach (var call in calls)
            {
                string[] stringPorts = call.Split('|');
                int port0 = Int32.Parse(stringPorts[0]);
                int port1 = Int32.Parse(stringPorts[1]);
                if (GenerateCallEvent != null) GenerateCallEvent(port0,port1);
            }
        }

        /*private void OnAcceptCall(object sender, GenerateCallEventArgs e)
        {
            if (handler != null)
            {
                GenerateCall(e.Terminal0, e.Terminal1);
                Console.WriteLine("Ebashit");
            }
        }*/

        public void GenerateCall(int port0, int port1)
        {
            if (Clients[port0].Terminal.Status == StatusPort.On &&
                Clients[port1].Terminal.Status == StatusPort.On)
            {
                
                int duration = _rnd.Next(1, 10);
                Calls.Add(new Call
                {
                    Port0 = Clients[port0].Terminal,
                    Port1 = Clients[port1].Terminal,
                    Duration = duration
                });
                Clients[port0].Terminal.Status = StatusPort.Busy;
                Clients[port1].Terminal.Status = StatusPort.Busy;
            }
            else
            {
                Console.WriteLine("Call {0} - {1} is impossible", Clients[port0].Show(), Clients[port1].Show());
            }
        }

        public static void AddContract(string firstName, string lastName)
        {
            var usingPorts = Clients.Count;
            var newClient = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                Terminal = new Terminal(usingPorts),
                Number = ArchiveNumbers[usingPorts],
                Tariff = new Tariff(StatusTariff.Default)
            };
            Clients.Add(newClient);
        }

        public void WriteClients()
        {
            string infoBase = Clients.Aggregate("Clients in ATS:\r\n",
                (current, client) => current + client.Show() + "\r\n");
            infoBase = infoBase + "-----------------------------------------------\r\n";
            File.WriteAllText(OutputFile, infoBase);
        }

        public void WriteCalls()
        {
            string infoBase = "All calls in ATS:\r\n";
            infoBase = Calls.Aggregate(infoBase, (current, call) => current + call.ToString() + "\r\n");
            File.AppendAllText(OutputFile, infoBase);
        }
    }
}
