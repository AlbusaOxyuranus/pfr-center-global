using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace O2.ToolKit.Core
{
    public interface INavigationService
    {
        Type FrameType
        {
            get;
        }
     
        bool Navigate(Type type, ViewModelBase dataContext = null, NavigationMode mode = NavigationMode.Clear);
        Task<bool> Navigate(string uri);
        bool Back(ViewModelBase dataContextObservableObject = null);
        Task<bool> NavigateAsync<T>(T type) where T : Page;

    }
   
}

