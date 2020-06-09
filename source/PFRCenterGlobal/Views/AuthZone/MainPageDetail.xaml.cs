using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace PFRCenterGlobal.Views.AuthZone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : Xamarin.Forms.TabbedPage
    {
        public MainPageDetail()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
