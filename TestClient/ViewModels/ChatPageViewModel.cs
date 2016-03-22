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
            //var chatClientImpl = new ChatClientImpl();
            //var channelFactory = new DuplexChannelFactory<IChatService>(chatClientImpl, "ChatServiceEndpoint");
            var channelFactory = new DuplexChannelFactory<IChatService>(new ChatClientImpl(), "ChatServiceEndpoint");
            var server = channelFactory.CreateChannel();

            User = Environment.UserName.ToString(); 
            server.Login(User);
        }

        private string _User;

        public string User
        {
            get { return _User; }
            set
            {
                _User = Environment.UserName.ToString();
                OnPropertyChanged("User");
                //_User = value;
            }
        }

    }
}
