using System;
using System.Threading.Tasks;
using PFRCenterGlobal.ViewModels.Interfaces;
using Xamarin.Essentials;

namespace PFRCenterGlobal.ViewModels.Logic
{
    internal class MainItemLogic : IMainItemMethods
    {
        private IMainItem mainItemViewModel;

        public MainItemLogic(IMainItem mainItemViewModel)
        {
            this.mainItemViewModel = mainItemViewModel;
        }

        public async Task OpenUrl()
        {
            var uri = new Uri(this.mainItemViewModel.UrlSite);
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}