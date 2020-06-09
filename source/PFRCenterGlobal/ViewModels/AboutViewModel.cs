using System;
using O2.ToolKit.Core;
using PFRCenterGlobal.Helpers;

namespace PFRCenterGlobal.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        #region Ctors
        public AboutViewModel()
        {
            VersionValue = HelperVersion.VersionValue;
        }
        #endregion


        #region Fields

        public string VersionValue { get; set; }
        #endregion


        #region Methods


        #endregion
    }
}
