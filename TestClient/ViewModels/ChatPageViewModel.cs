using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ChatInterfaces;
using System.Windows.Input;

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
                //redundant code?
                _User = Environment.UserName.ToString();
                OnPropertyChanged("User");
                //_User = value;
            }
        }

        private ICommand _sendButton;

        public ICommand sendButton
        {
            get 
            {
                if (_sendButton == null)
                {
                    _sendButton = new Command(SendButton, CanPressSendButton);
                }
                return _sendButton; 
            }
            set { _sendButton = value; }
        }

        public void SendButton()
        {

        }

        public bool CanPressSendButton()
        {
            return true;
        }
        
    }
}
