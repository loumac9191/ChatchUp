using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ChatInterfaces;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace TestClient.ViewModels
{
    public class ChatPageViewModel : BaseViewModel
    {
        DuplexChannelFactory<IChatService> channelFactory;
        List<string> usersLoggedIn; 


        public ChatPageViewModel()
        {
            //var chatClientImpl = new ChatClientImpl();
            //var channelFactory = new DuplexChannelFactory<IChatService>(chatClientImpl, "ChatServiceEndpoint");
            channelFactory = new DuplexChannelFactory<IChatService>(new ChatClientImpl(), "ChatServiceEndpoint");
            var server = channelFactory.CreateChannel();

            User = Environment.UserName.ToString(); 
            server.Login(User);

            usersLoggedIn = server.UsernameInChat();
            userList = new ObservableCollection<string>(usersLoggedIn);

        }

        //UPDATE
        //private void UpdateCommands()
        //{
        //    ((Command)itemToRemoveFromDatabase).RaiseCanExecuteChanged();
        //}

        private string _User;

        public string User
        {
            get { return _User; }
            set
            {
                _User = value;
                OnPropertyChanged("User");
            }
        }

        //SEND BUTTON
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
            //METHOD FOR SENDING MESSAGES
        }

        public bool CanPressSendButton()
        {
            return true;
        }

        //SEND MESSAGE IN TEXTBOX
        private string _messageToSend;

        public string messageToSend
        {
            get { return _messageToSend; }
            set 
            {
                _messageToSend = value;
                OnPropertyChanged("messageToSend");
            }
        }

        //MESSAGES THAT APPEAR IN THE MAIN LISTBOX
        //UNFINISHED
        private string _text;

        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
        
        //LIST OF USERS
        private ObservableCollection<string> _userList;

        public ObservableCollection<string> userList
        {
            get { return _userList; }
            set 
            {
                _userList = value;
                OnPropertyChanged("userList");
            }
        }

        //METHOD FOR GETTING USER LIST  
        public void AllUsersCurrentlyLoggedIn()
        {
            //userList = server.UsernameInChat();
        }
        
        
    }
}
