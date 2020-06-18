using System;
using System.Collections.ObjectModel;
using O2.ToolKit.Core;

namespace PFRCenterGlobal.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel() => _items = new ObservableCollection<MainItemViewModel>()
            {
                new MainItemViewModel(){
                    Title="Официальный сайт Московского центра ПФР",
                    UrlSite="https://pfr-centr.com",
                    Content = "<a style=\"color: green;\" href=\"https://pfr-centr.com\">https://pfr-centr.com</a>",
                    OpenDate=new DateTime(2019,12,12) },
                new MainItemViewModel(){ Title="Официальный очного обучения",
                    Content = "<a href=\"https://antonmarkov.com\">https://antonmarkov.com</a>",
                    UrlSite="https://antonmarkov.com",
                    OpenDate=new DateTime(2019,12,12) },
                new MainItemViewModel(){
                    Title="Официальный заочного обучения",
                     UrlSite="https://hypnosdoma.com",
                    Content = "<a href=\"https://hypnosdoma.com\">https://hypnosdoma.com</a>",
                    OpenDate=new DateTime(2019,12,12) }
            };
        private ObservableCollection<MainItemViewModel> _items;
        //private ObservableCollection<CertificateViewModel> certificates;
        //private ObservableCollection<EventViewModel> events;

        //#region Ctor

        //#endregion


        //#region Fields

        //public ObservableCollection<CertificateViewModel> Certificates
        //{
        //    get => certificates; set
        //    {
        //        certificates = value;
        //        OnPropertyChanged();
        //    }
        //}

        public ObservableCollection<MainItemViewModel> Items
        {
            get => _items; set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        //#endregion


        //#region Methods

        //#endregion
    }
}
