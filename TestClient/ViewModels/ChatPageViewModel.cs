using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ChatInterfaces;

namespace TestClient.ViewModels
{
    public class ChatPageViewModel : BaseViewModel
    {
        public ChatPageViewModel()
        {
            var channelFactory = new DuplexChannelFactory<IChatService>(new ChatClientImpl(), "ChatServiceEndpoint");
            var server = channelFactory.CreateChannel();

            server.Login(Environment.UserName);
        }

        private string _User;

        public string User
        {
            get { return _User; }
            set
            {
                _User = Environment.UserName.ToString();
            }
        }

    }
}
