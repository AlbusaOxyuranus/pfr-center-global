using System;
using System.Threading.Tasks;
using O2.ToolKit.Core;
using Xamarin.Forms;

namespace PFRCenterGlobal.Helpers
{
    public class NavigationManager
    {
        #region implementation Singleton 

        private static volatile NavigationManager _instance;
        private static object syncRoot = new Object();

        private INavigationService _navigationService;
        public string FrameType => _navigationService.FrameType.ToString();

        public static NavigationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new NavigationManager();
#if !NETFX_CORE
                            _instance._navigationService = new NavigationServiceXamarin();
#elif !WINDOWS_UWP
                            _instance._navigationService = new NavigationServiceWp81();
#endif

#if WINDOWS_UWP
                            _instance._navigationService = new NavigationServiceUniversal();
#endif
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        public bool NavigateAsync(string uri)
        {
            return _navigationService.Navigate(uri).GetAwaiter().GetResult();
        }

        public async Task<bool> BackAsync(ViewModelBase dataContextObservableObject = null)
        {
            return await Task.FromResult(true);
            //return _navigationService.BackAsync(dataContextObservableObject);
        }



        public INavigationService NavigationService { get; set; }

        public bool NavigateAsync(Type type, ViewModelBase dataContext = null,
            NavigationMode mode = NavigationMode.Clear)
        {
            return _navigationService.Navigate(type, dataContext, mode);
            //return await Task.FromResult(true);
            //return await _navigationService.NavigateAsync(type, dataContext, mode);
        }
    }
}