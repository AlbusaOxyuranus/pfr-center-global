using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PFRCenterGlobal.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PFRCenterGlobal.Views.AuthZone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView;

        public MainPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

            public MainPageMasterViewModel() => MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
                {
                    new MainPageMenuItem { Id = 0, Title = "Main" },
                    new MainPageMenuItem { Id = 1, Title = "Account"},
                    new MainPageMenuItem { Id = 2, Title = "Cards" },
                    new MainPageMenuItem { Id = 3, Title = "Notifications" },
                    new MainPageMenuItem { Id = 4, Title = "About", TargetType=typeof(AboutPage) },
                    new MainPageMenuItem { Id = 5, Title = TranlateHelper.GetValue("SlideMenuExit"), IsExitApp=true }
                });

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion

        }
    }
}
