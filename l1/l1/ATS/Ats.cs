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
        private const string OutputFile = @"d:\epam\Tasks\l1\l1\ATS\Files\infoBase.txt";
        private const string InputFile = @"d:\epam\Tasks\l1\l1\ATS\Files\Contract1.txt";
        public event GenerateCallEngineHandler AcceptCall;

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
            if (Clients[port0].Terminal.Status == StatusPort.On ||
                Clients[port1].Terminal.Status == StatusPort.On)
            {
                Random rnd = new Random();
                int duration = rnd.Next(1, 10);
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
            infoBase = infoBase + "All calls in ATS:\r\n";
            infoBase = Calls.Aggregate(infoBase, (current, call) => current + call.ToString() + "\r\n");
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
