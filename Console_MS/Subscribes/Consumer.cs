using NATS.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_MS.Subscribes
{
    internal static class Consumer
    {
        internal static void SubscribeGetSimpleData(List<string> data)
        {
            EventHandler<MsgHandlerEventArgs> handler = (sender, args) =>
            {
                string d = Encoding.UTF8.GetString(args.Message.Data);
                data.Add(d);
            };
            IAsyncSubscription sub =Program.connection.SubscribeAsync("GetSimpleData", handler);
        }
    }
}
