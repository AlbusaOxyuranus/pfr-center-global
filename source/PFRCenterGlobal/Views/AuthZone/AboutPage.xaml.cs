using O2.ToolKit.Core;
using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;

namespace PFRCenterGlobal.Views.AuthZone
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            this.BindingContext = O2Store.CreateOrGet<AboutViewModel>();
        }
    }
}
