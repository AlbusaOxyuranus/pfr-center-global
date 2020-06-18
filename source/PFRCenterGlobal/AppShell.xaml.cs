using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using PFRCenterGlobal.Views.AuthZone;
using Xamarin.Forms;

namespace PFRCenterGlobal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            RegisterRoutes();
            this.BindingContext = this;
        }

        Dictionary<string, Type> routes = new Dictionary<string, Type>();

        public ICommand NavigateCommand => new Command(Navigate);
        public ICommand SettingsCommand => new Command(async()=> await PushPage(new AboutPage()));

        private async Task PushPage(Page page)
        {
            await Shell.Current.Navigation.PushAsync(page);
            Shell.Current.FlyoutIsPresented = false;
        }

        private  async void Navigate(object route)
        {
            //await Commander.GoToAsync(route);
            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"{state.Location}/{route.ToString()}");
            Shell.Current.FlyoutIsPresented = false;

        }

        void RegisterRoutes()
        {
            routes.Add("about", typeof(AboutPage));
            routes.Add("certificate_detail", typeof(CertificateDetailPage));
            routes.Add("certificates", typeof(CertificatesPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
