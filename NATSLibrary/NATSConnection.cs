using NATS.Client;
namespace NATSLibrary
{
    static public class NATSConnection
    {
        public static IConnection Connect()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            var opt = ConnectionFactory.GetDefaultOptions();
            opt.Url = "nats://localhost:4222";
            return connectionFactory.CreateConnection(opt);
        }
    }
}