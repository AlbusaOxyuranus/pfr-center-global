namespace PFRCenterGlobal.ViewModels.Maps
{
    public class Result
    {
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Opening_Hours opening_hours { get; set; }
        public Photo[] photos { get; set; }
        public string place_id { get; set; }
        public Plus_Code plus_code { get; set; }
        public float rating { get; set; }
        public string reference { get; set; }
        public string[] types { get; set; }
        public int user_ratings_total { get; set; }
        public string vicinity { get; set; }
        public string scope { get; set; }
    }
}