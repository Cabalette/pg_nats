using NATSLibrary;
using NATS.Client;
using System.Text;
using db_ms.DBContext;
using db_ms.Methods;

namespace db_ms
{
    public class Program
    {
        private const string ALLOWED_OPTIONS = "123456qQ";
        internal static IConnection connection;
        internal const int sendIntervalMs = 100;
        public static void Main(string[] args)
        {
            //Scaffold-DbContext "Host=localhost;Database=pgnats;Username=postgres;Password=123" Npgsql.EntityFrameworkCore.PostgreSQL
            bool stop = false;

            using (connection = NATSConnection.Connect())
            {
                while (!stop)
                {
                    Console.Clear();

                    Console.WriteLine("NATS demo producer");
                    Console.WriteLine("==================");
                    Console.WriteLine("Select mode:");
                    Console.WriteLine("1. Просто получить данные из БД");

                    ConsoleKeyInfo key;
                    do
                    {
                        key = Console.ReadKey();
                    } while (!ALLOWED_OPTIONS.Contains(key.KeyChar));

                    switch (key.KeyChar)
                    {
                        case '1':
                            Producer.GetSimpleData();
                            break;

                    }
                    Console.WriteLine();
                    Console.WriteLine("Done. Press any key to continue...");
                    Console.ReadKey(true);
                }
            }
            //var query2 = context.People.GroupJoin(context.Cars, x => x.Id, x => x.PeopleId, (x, e) => new
            //{
            //    x.FirstName,
            //    x.LastName,
            //    Cars = e
            //}).ToArray();
        }
    }
}