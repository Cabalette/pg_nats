using db_ms.DBContext;
using System.Text;

namespace db_ms.Methods
{
    internal static class Producer
    {
        internal static void GetSimpleData()
        {
            using (PgnatsContext context = new())
            {
                var query = context.People;
                foreach (var p in query)
                {
                    var id = p.Id.ToString();
                    var firstName = p.FirstName.ToString();
                    var lastName = p.LastName.ToString();
                    byte[][] bytes = new byte[3][];
                    bytes[0] = Encoding.UTF8.GetBytes(id);
                    bytes[1] = Encoding.UTF8.GetBytes(firstName);
                    bytes[2] = Encoding.UTF8.GetBytes(lastName);

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        Program.connection.Publish("GetSimpleData", bytes[i]);
                        Thread.Sleep(Program.sendIntervalMs);
                    }
                }
            }
        }

    }
}
