using ChatInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestClient.ViewModels;

namespace TestClient
{
    internal class ChatClientImpl : IChatClient
    {
        
        public void ReceiveMessage(string userName, string message)
        {
            Frame frame = App.Current.MainWindow.FindName("MainFrame") as Frame;
            ChatPage chatPage = frame.Content as ChatPage;
            ChatPageViewModel cpvm = chatPage.DataContext as ChatPageViewModel;
            cpvm.text.Add(String.Format("{0}: {1}", userName, message));
        }

        public void UpdateUserList(string userName)
        {

        }
    }
}
