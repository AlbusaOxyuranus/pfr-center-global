using Xamarin.Forms.Maps;

namespace PFRCenterGlobal.ViewModels.Maps
{
    public class Place
    {
        public string PlaceName { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
        public string Distance { get; set; }
        public string OpenNow { get; set; }
        public Position Position { get; set; }
        public Location Location { get; set; }
    }
}