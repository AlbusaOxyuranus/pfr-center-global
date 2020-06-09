using System;
using O2.ToolKit.Core.Commands;

namespace PFRCenterGlobal.ViewModels.Interfaces
{
    internal interface IMainItem
    {
        string Title { get; set; }
        string UrlSite { get; set; }
        string Content { get; set; }
        DateTime OpenDate { get; set; }
        IAsyncCommand OpenUrlCommand { get; }
        IMainItemMethods IMainItemMethods { get;  }
    }
}