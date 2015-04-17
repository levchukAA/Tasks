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
        private const string ClientsFile = @"d:\epam\Tasks\l1\l1\ATS\Files\Clients.txt";
        private const string CallsFile = @"d:\epam\Tasks\l1\l1\ATS\Files\Calls.txt";
        private const string OperationsFile = @"d:\epam\Tasks\l1\l1\ATS\Files\Operations.txt";
        private const string InputFile = @"d:\epam\Tasks\l1\l1\ATS\Files\Contract1.txt";
        readonly Random _rnd = new Random();
        private static string _operation = "";
        public delegate void GenerateCallDelegate(int port0, int port1);
        public event GenerateCallDelegate GenerateCallEvent;
        public static readonly List<Client> Clients = new List<Client>();
        public static readonly List<Call> Calls = new List<Call>();
        public static readonly int[] ArchiveNumbers = new int[90000];
        

        public ATS()
        {
            File.Delete(ClientsFile);
            File.Delete(CallsFile);
            File.Delete(OperationsFile);
            GenerateNumbers();
            MethodsForFiles.ReadContracts(InputFile);
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

        public void ReadEvents(string path)
        {
            GenerateCallEvent += GenerateCall;
            string[] calls = InfoFromFile.GetTextFile(path).Split('\n');
            foreach (var call in calls)
            {
                string[] stringPorts = call.Split('|');
                int port0 = Int32.Parse(stringPorts[0]);
                int port1 = Int32.Parse(stringPorts[1]);
                if (GenerateCallEvent != null) GenerateCallEvent(port0, port1);
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
                Call newCall = new Call
                {
                    Port0 = Clients[port0].Terminal,
                    Port1 = Clients[port1].Terminal,
                    Duration = duration
                };
                Calls.Add(newCall);
                Clients[port0].Terminal.Status = StatusPort.Busy;
                Clients[port1].Terminal.Status = StatusPort.Busy;
                _operation = "Client " + Clients[port0].Name + " calls to "  + Clients[port1].Name +
                    ", duration = " + newCall.Duration + ", at " + DateTime.Now;
                WriteCall(newCall);
                WriteOperation(_operation);
            }
            else
            {
                _operation = "Client " + Clients[port0].Name + " calls to " + Clients[port1].Name +
                    " but this call was unsuccessful";
                WriteOperation(_operation);
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
            _operation = "In ATS was added new client " + newClient.Name;
            Clients.Add(newClient);
            WriteClient(newClient);
            WriteOperation(_operation);
        }

        public static void WriteClient(Client client)
        {
            File.AppendAllText(ClientsFile, client.Show() + "\r\n");
        }

        public void WriteCall(Call call)
        {
            File.AppendAllText(CallsFile, call + "\r\n");
        }

        public static void WriteOperation(string operation)
        {
            File.AppendAllText(OperationsFile, operation + "\r\n");
        }
    }
}
