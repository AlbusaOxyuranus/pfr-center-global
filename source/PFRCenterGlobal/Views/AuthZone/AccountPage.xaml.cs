using O2.ToolKit.Core;
using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PFRCenterGlobal.Views.AuthZone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
            var accountVm = O2Store.CreateOrGet<AccountViewModel>();

            accountVm.Firstname = "Denis";
            accountVm.Lastname = "Prox";
            accountVm.PhoneNumber = "+375447987208";
            accountVm.AccountId = "375447987208";
            accountVm.Username = "denisprokhorchik";

            BindingContext = accountVm;
        }
    }
}