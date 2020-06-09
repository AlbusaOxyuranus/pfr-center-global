using System;
using System.Collections.Generic;
using O2.ToolKit.Core;
using Xamarin.Forms;

namespace PFRCenterGlobal.Views.AuthZone
{
    public partial class EventsPage : ContentPage
    {
        public EventsPage()
        {
            InitializeComponent();
            BindingContext = O2Store.CreateOrGet<EventListViewModel>();
        }
    }
}
