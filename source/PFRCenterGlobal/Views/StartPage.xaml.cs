using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PFRCenterGlobal.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }
        
        public void AddMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // if (messageDisplay.Children.OfType<Label>().Where(c => c.Text == message).Any())
                // {
                //     // Do nothing, an identical message already exists
                // }
                // else
                // {
                //     Label label = new Label()
                //     {
                //         Text = message,
                //         HorizontalOptions = LayoutOptions.CenterAndExpand,
                //         VerticalOptions = LayoutOptions.Start
                //     };
                //     messageDisplay.Children.Add(label);
                // }
            });
        }
    }
}
