using System.Threading.Tasks;
using O2.ToolKit.Core;
using PFRCenterGlobal.Helpers;
using PFRCenterGlobal.ViewModels.Interfaces;
using PFRCenterGlobal.Views.AuthZone;

namespace PFRCenterGlobal.ViewModels.Logic
{
    public class CertificateLogic : ICertificateLogic

    {
        #region Props

        protected ICertificate Certificate { get; private set; }

        #endregion


        #region Ctors

        public CertificateLogic(ICertificate certificate)
        {
            Certificate = certificate;

        }


        #endregion

        #region Methods
        public async Task OpenCertificate()
        {
            await Commander.GoToAsync(new CertificateDetailPage());
            //await Task.Delay(100);
            //O2Store.CreateOrGet<CertificateListViewModel>().SelectedItem = (CertificateViewModel) Certificate;
            //NavigationManager.Instance.NavigateAsync(typeof(CertificateDetailPage));
            //await Shell.Current.GoToAsync($"certificatedetail");
            //App.Current.MainPage = new NavigationPage(new CertificateDetailPage());
        }

        #endregion
    }
}
