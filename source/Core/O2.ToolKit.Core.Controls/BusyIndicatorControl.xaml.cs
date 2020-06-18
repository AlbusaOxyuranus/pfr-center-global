using System;
using Xamarin.Forms;

namespace O2.ToolKit.Core.Controls
{
    public partial class BusyIndicatorControl : ContentView
    {
        public BusyIndicatorControl()
        {
            this.InitializeComponent();
        }


        // Dependency Property
        public static readonly BindableProperty MessageProperty =
             BindableProperty.Create("Message", typeof(string),
             typeof(BusyIndicatorControl),default(string),propertyChanged:UpdateMessage);

        private static void UpdateMessage(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as BusyIndicatorControl).Message = (string)newValue;
        }


        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }



        public bool LoadState
        {
            get { return (bool)GetValue(LoadStateProperty); }
            set
            {
                SetValue(LoadStateProperty, value);
            }

        }

        // Dependency Property
        public static readonly BindableProperty LoadStateProperty =
            BindableProperty.Create("LoadState", typeof(bool),
             typeof(BusyIndicatorControl), default(bool),propertyChanged:UpdateState);

        private static void UpdateState(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)newValue)
            {
                //var currentPage = Application.Current.MainPage as Page;
                //if (currentPage.ToolbarItems != null)
                //{
                //    currentPage.ToolbarItems.isv = false;
                //}
                //currentPage.Focus();
                (bindable as BusyIndicatorControl).IsVisible = true;

            }
            else
            {

                //var currentPage = ((PhoneApplicationFrame)Application.Current.RootVisual).Content as PhoneApplicationPage;
                //if (currentPage.ApplicationBar != null)
                //{
                //    currentPage.ApplicationBar.IsVisible = true;
                //}
                 (bindable as BusyIndicatorControl).IsVisible = false;
            }
        }
    }
}
