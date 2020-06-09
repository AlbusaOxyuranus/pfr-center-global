using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using O2.ToolKit.Core;
using PFRCenterGlobal.Models;

namespace PFRCenterGlobal.ViewModels
{
    public class CertificateListViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<CertificateViewModel> items;
        private CertificateViewModel selectedItem = new CertificateViewModel();

        #endregion


        #region Props
        public CertificateViewModel SelectedItem
        {
            get => selectedItem; set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CertificateViewModel> Items
        {
            get => items; set
            {
                items = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Ctors

        public CertificateListViewModel()
        {
            Items = new ObservableCollection<CertificateViewModel>()
            {
                new CertificateViewModel()
                {
                    Id=Guid.NewGuid(),
                    Serial="A",
                    Number="0001022020",
                    ShortNumber=1
                }
            };
            //SelectedItem = Items.First();
        }

        #endregion


        #region Methods

        public static ObservableCollection<CertificateViewModel> GetData()
        {
            var dataItems = new ObservableCollection<CertificateViewModel>();
            var assembly = typeof(CertificateViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("PFRCenterGlobal.Data.Data.json");

            using (var reader = new StreamReader(stream))
            {

                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<List<O2CCertificateForReturnDto>>(json);

                foreach (var item in data)
                {
                    dataItems.Add(new CertificateViewModel { Serial=item.Serial, Number = item.Number,
                        ShortNumber=item.ShortNumber,
                        Lastname = item.Lastname,
                        Firstname = item.Firstname,
                        Middlename = item.Middlename,
                        PhotoUrl = item.PhotoUrl == null ? null : new Uri(item.PhotoUrl),
                        AllLocations = item.AllLocations
                    });;
                }

                if (dataItems != null)
                    return dataItems;

                return new ObservableCollection<CertificateViewModel>()
                 {

                new CertificateViewModel(){
                    Firstname="Denis",
                    Lastname="Prox"},
                                new CertificateViewModel(){
                                    Firstname="Denis2",
                                    Lastname="Prox2"}
                            };
            }
        }
        

        #endregion

    }
}
