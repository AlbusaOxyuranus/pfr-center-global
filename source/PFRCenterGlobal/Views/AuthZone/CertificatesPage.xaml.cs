using System.Linq;
using O2.ToolKit.Core;
using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;

namespace PFRCenterGlobal.Views.AuthZone
{
    public partial class CertificatesPage : ContentPage
    {
        public CertificatesPage()
        {
            InitializeComponent();
            BindingContext = O2Store.CreateOrGet<CertificateListViewModel>();
            
        }

        protected override void OnAppearing()
        {
            O2Store.CreateOrGet<CertificateListViewModel>().Items = CertificateListViewModel.GetData();
            base.OnAppearing();
        }
        private async void ListViewCertificates_ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var item = (e.CurrentSelection.FirstOrDefault() as CertificateViewModel);
            O2Store.CreateOrGet<CertificateListViewModel>().SelectedItem = item;
            if (item == null)
                return;

            await item.OpenCertificate();
        }
    }
}
