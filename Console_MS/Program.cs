using NATS.Client;
using NATSLibrary;
using System.ComponentModel;
using System.Text;
using Console_MS.Subscribes;

namespace Console_MS
{
    public class Program
    {
        public static IConnection connection;
        static void Main(string[] args)
        {
            using (connection = NATSConnection.Connect())
            {
                List<string> data = new();
                Consumer.SubscribeGetSimpleData(data);
                Console.ReadKey(true);
            }
        }

    }
}