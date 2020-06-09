namespace PFRCenterGlobal.ViewModels.Maps
{
    public class Places
    {
        public object[] html_attributions { get; set; }
        public string next_page_token { get; set; }
        public Result[] results { get; set; }
        public string status { get; set; }
    }
}