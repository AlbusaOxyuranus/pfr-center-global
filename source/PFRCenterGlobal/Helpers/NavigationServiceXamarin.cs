using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using O2.ToolKit.Core;
using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;

namespace PFRCenterGlobal.Helpers
{
    internal class NavigationServiceXamarin : INavigationService
    {
        #region Ctors
        public NavigationServiceXamarin()
        {
            if (SessionViewModel.Instance.SessionState == SessionState.New)
            {
                //Application.Current.RootVisual.Tap += RootFrame_Tap;
            }
        }

        #endregion

        public static Page Frame => App.Current.MainPage;

        public Type FrameType
        {
            get { return typeof(Frame); }
        }

        public async System.Threading.Tasks.Task<bool> BackAsync(ViewModelBase dataContextObservableObject = null)
        {

            //DebugNavigation();
            //await Frame.PopAsync();
            return true;
        }

        public static ViewModelBase ObservableObjectBackDataContext { get; set; }

        public string GetViewPath(Type type)
        {
            var assemblyName = type.Assembly.GetName().Name;
            var path = type.FullName.Replace(assemblyName, string.Empty).Replace(".", "/");
            //if (!isFull) return string.Format("{0}.xaml", path);
            return $"/{path}.xaml";
        }


        public bool Navigate(Type type, ViewModelBase dataContext = null, NavigationMode mode = NavigationMode.Clear)
        {

            //DebugNavigation();
            string path = GetViewPath(type);
            switch (mode)
            {
                case NavigationMode.SaveBack:
                    {
                        //        //CleanBackStack();
                        //        //Save Back DataContext 
                        //        var phoneApplicationFrameCurrent = Application.Current.RootVisual as PhoneApplicationFrame;
                        //        if (phoneApplicationFrameCurrent != null)
                        //            ObservableObjectBackDataContext = (ObservableObject)phoneApplicationFrameCurrent.DataContext;

                        //        if (!Frame.Navigate(new Uri(path, UriKind.RelativeOrAbsolute))) return false;

                        //        var phoneApplicationFrame = Application.Current.RootVisual as PhoneApplicationFrame;
                        //        if (phoneApplicationFrame != null)
                        //            phoneApplicationFrame.DataContext = dataContext;
                    }
                    break;
                case NavigationMode.Clear:
                    {
                        
                        //var result = Frame as Shell;
                        Shell.Current.GoToAsync(new Uri(path, UriKind.RelativeOrAbsolute)).GetAwaiter().GetResult();
                        //        CleanBackStack();
                        //        var phoneApplicationFrame = Application.Current.RootVisual as PhoneApplicationFrame;
                        //        if (phoneApplicationFrame != null)
                        //            phoneApplicationFrame.DataContext = dataContext;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
            return true;
        }

        public async Task<bool> Navigate(string uri)
        {
            await (Frame as Shell).GoToAsync(new Uri(uri, UriKind.RelativeOrAbsolute));
            //CleanBackStack();
            return true;
        }

        public bool Back(ViewModelBase dataContextObservableObject = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> NavigateAsync<T>(T type) where T : Page
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> NavigateAsync<T>(T type)
        //    where T : Page
        //{
        //    if (type is null)
        //    {
        //        throw new ArgumentNullException(nameof(type));
        //    }

        //    return true;
        //}

    }
}