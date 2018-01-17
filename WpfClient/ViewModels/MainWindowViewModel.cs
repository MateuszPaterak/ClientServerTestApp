using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using WebService.Models;
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
            var res = await ServiceAgent.AddUserAsync(_user);
            if(res)
            { MessageBox.Show("Informacja została wysłana");}
            else
            { MessageBox.Show("Wystąpił problem");}
            //Notification = "Użytkownik został dodany";
        }
    }
}
