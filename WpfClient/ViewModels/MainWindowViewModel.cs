using System;
using System.Windows;
using Caliburn.Micro;
using PluginInterface;
using WpfClient.Models;

namespace WpfClient.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private User _user = new User();
        private string _notification = String.Empty;

        public string TbName
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                NotifyOfPropertyChange(nameof(TbName));
            }
        }
        public string TbSurname
        {
            get { return _user.Surname; }
            set
            {
                _user.Surname = value;
                NotifyOfPropertyChange(nameof(TbSurname));
            }
        }
        public string TbEmail
        {
            get { return _user.Email; }
            set
            {
                _user.Email = value;
                NotifyOfPropertyChange(nameof(TbEmail));
            }
        }

        public string Notification
        {
            get { return _notification; }
            set
            {
                _notification = value;
                NotifyOfPropertyChange(nameof(Notification));
            }
        }

        public async void BtAddUser()
        {
            try
            {
                var res = await ServiceAgent.AddUserAsync(_user);
                MessageBox.Show(res ? "Użytkownik został zapisany" : "Wystąpił problem");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
