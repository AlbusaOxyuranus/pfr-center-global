using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PFRCenterGlobal.Helpers
{
    //[ContentProperty("Text")]
    [ContentProperty("Text")]
    public class TranslateExtension: IMarkupExtension
    {
        const string ResourceId = "PFRCenterGlobal.Resources.AppResources";
        public string Text { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;
            ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            return resourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }
    }

    public static class TranlateHelper
    {
        const string ResourceId = "PFRCenterGlobal.Resources.AppResources";
        public static string GetValue(string key)
        {
            ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
    }
}
