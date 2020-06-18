using System;
using System.Threading.Tasks;
using O2.ToolKit.Core;
using O2.ToolKit.Core.Commands;
using PFRCenterGlobal.Helpers;
using PFRCenterGlobal.ViewModels.Interfaces;
using PFRCenterGlobal.ViewModels.Logic;

namespace PFRCenterGlobal.ViewModels
{
    public class MainItemViewModel : ViewModelBase,
        IMainItem, IMainItemCommand, IMainItemMethods
    {
        private string title;
        private string content;
        private DateTime openDate;
        private string urlSite;

        public MainItemViewModel()
        {
            OpenUrlCommand = AsyncCommand.Create(OpenUrl);
            IMainItemMethods = new MainItemLogic(this);
        }



        public string Title
        {
            get => title; set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string Content
        {
            get => content; set
            {
                content = value;
                OnPropertyChanged();
            }
        }

        public DateTime OpenDate
        {
            get => openDate; set
            {
                openDate = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand OpenUrlCommand { get; private set; }
        public IMainItemMethods IMainItemMethods { get; private set; }
        public string UrlSite
        {
            get => urlSite; set
            {
                urlSite = value;
                OnPropertyChanged();
            }
        }

        public async Task OpenUrl()
        {
            await HelperBussinessProcess.Start(this,
                  async () =>
                  {
                      await IMainItemMethods.OpenUrl();
                  }
               );
        }
    }
}