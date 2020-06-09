using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFRCenterGlobal.Helpers;
using PFRCenterGlobal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PFRCenterGlobal.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register1Page : ContentPage
    {
        public Register1Page()
        {
            InitializeComponent();
            BindingContext = O2.ToolKit.Core.O2Store.CreateOrGet<RegisterViewModel>();
            NavigationCommander.Navigation = this.Navigation;
        }

        private void OnLabelTapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}