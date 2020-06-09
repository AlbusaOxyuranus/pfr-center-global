using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PFRCenterGlobal.ViewModels.RegisterStep3Logic;

namespace PFRCenterGlobal.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register3Page : ContentPage
    {
        public Register3Page()
        {
            InitializeComponent();
            BindingContext = O2.ToolKit.Core.O2Store.CreateOrGet<RegisterViewModel>();
        }
    }
}