using System;
using System.Threading.Tasks;
using O2.ToolKit.Core;
using O2.ToolKit.Core.Commands;
using PFRCenterGlobal.Helpers;
using PFRCenterGlobal.ViewModels.Interfaces;
using PFRCenterGlobal.ViewModels.Logic;

namespace PFRCenterGlobal.ViewModels
{
    public class CertificateViewModel :
        ViewModelBase, ICertificate, ICertificateLogic
    {
        #region Fields

        private Guid id;
        private string serial;
        private int shortNumber;
        private string number;
        private string lastname;
        private string firstname;
        private string middlename;
        private Uri photoUrl;
        private string allLocations;

        #endregion


        #region Ctors
        public CertificateViewModel()
        {
            OpenCertificateAsyncCommand = AsyncCommand.Create(OpenCertificate);
            CertificateLogic = new CertificateLogic(this);
        }


        #endregion


        #region Props
        public IAsyncCommand OpenCertificateAsyncCommand { get; private set; }
        public ICertificateLogic CertificateLogic { get; set; }

        public Guid Id
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Serial
        {
            get => serial; set
            {
                serial = value;
                OnPropertyChanged();
            }
        }

        public string Number
        {
            get => number; set
            {
                number = value;
                OnPropertyChanged();
            }
        }

        public int ShortNumber
        {
            get => shortNumber; set
            {
                shortNumber = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get => lastname; set
            {
                lastname = value;
                OnPropertyChanged();
            }
        }
        public string Firstname
        {
            get => firstname; set
            {
                firstname = value;
                OnPropertyChanged();
            }
        }
        public string Middlename
        {
            get => middlename;
            set
            {
                middlename = value;
                OnPropertyChanged();
            }
        }

        public Uri PhotoUrl
        {
            get => photoUrl;
            set
            {
                photoUrl = value;
                OnPropertyChanged();
            }
        }

        public string AllLocations
        {
            get => allLocations;
            set
            {
                allLocations = value;
                OnPropertyChanged();
            }
        }

        public async Task OpenCertificate()
        {
            await HelperBussinessProcess.Start(this,
                  async () =>
                  {
                      await CertificateLogic.OpenCertificate();
                  }
               );
        }

        #endregion

        #region Methods

        #endregion
    }
}
