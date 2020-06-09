using O2.ToolKit.Core;
using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;

namespace PFRCenterGlobal.Views.AuthZone
{
    public partial class CertificateDetailPage : ContentPage
    {
        public CertificateDetailPage()
        {
            InitializeComponent();
            BindingContext = O2Store.CreateOrGet<CertificateListViewModel>().SelectedItem;
        }
    }
}
