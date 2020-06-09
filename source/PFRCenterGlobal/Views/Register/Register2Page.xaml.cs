using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PFRCenterGlobal.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register2Page : ContentPage
    {
        public Register2Page()
        {
            InitializeComponent();
            BindingContext = O2.ToolKit.Core.O2Store.CreateOrGet<RegisterViewModel>();
        }
    }
}