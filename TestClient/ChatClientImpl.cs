using ChatInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    public class ChatClientImpl : IChatClient
    {
        public void ReceiveMessage(string userName, string message)
        {
            Console.WriteLine("{0}: {1}", userName, message);
        }
    }
}
