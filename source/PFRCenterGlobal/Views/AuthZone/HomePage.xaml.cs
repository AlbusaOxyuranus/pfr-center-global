using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;

namespace PFRCenterGlobal.Views.AuthZone
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = O2.ToolKit.Core.O2Store.CreateOrGet<MainViewModel>();
        }

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null)
                return;
            MainItemViewModel selectedItem  = (MainItemViewModel)e.CurrentSelection.First();
            if(selectedItem!=null)
                selectedItem.OpenUrlCommand.Execute(null);

        }

    }
}
