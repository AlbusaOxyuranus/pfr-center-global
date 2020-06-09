using PFRCenterGlobal.Helpers;
using PFRCenterGlobal.Views.Register;
using Xamarin.Forms;

namespace PFRCenterGlobal
{
    public partial class App : Application
    {
        //private static string _notificationReceivedKey;

        public App()
        {
            InitializeComponent();
            //MainPage = new AppShell();

            MainPage = new NavigationPage(new Register1Page());
            NavigationCommander.App = this;
            NavigationCommander.Current = this.MainPage;
        }
    }
}
