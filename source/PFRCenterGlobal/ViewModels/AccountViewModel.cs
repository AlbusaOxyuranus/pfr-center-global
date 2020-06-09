using O2.ToolKit.Core;
using PFRCenterGlobal.ViewModels.Interfaces;
using System;
using System.Threading.Tasks;

namespace PFRCenterGlobal.ViewModels
{
    public class AccountViewModel:
        ViewModelBase,
        IAccount,
        IAccountLogic
    {
        private string username;
        private string phoneNumber;
        private string firstname;
        private string lastname;
        private string accountId;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Firstname
        {
            get => firstname;
            set
            {
                firstname = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get => lastname;
            set
            {
                lastname = value;
                OnPropertyChanged();
            }
        }

        public string AccountId
        {
            get => accountId;
            set
            {
                accountId = value;
                OnPropertyChanged();
            }
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task SavePassword()
        {
            throw new NotImplementedException();
        }
    }
}
