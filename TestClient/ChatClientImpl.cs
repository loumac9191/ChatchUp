using ChatInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.ViewModels;

namespace TestClient
{
    public class ChatClientImpl : IChatClient
    {
        public void ReceiveMessage(string userName, string message)
        {
            ChatPageViewModel s = App.Current.MainWindow.DataContext as ChatPageViewModel;
            s.text.Add(String.Format("{0}: {1}", userName, message));



            //Console.WriteLine("{0}: {1}", userName, message);
        }
    }
}
