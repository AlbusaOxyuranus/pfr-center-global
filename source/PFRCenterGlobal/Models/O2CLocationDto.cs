using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace PFRCenterGlobal.Models
{
    [DataContract]
    public class O2CLocationDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "added_date")]
        public long AddedDate { get; set; }

        [JsonProperty(PropertyName = "modified_date")]
        public long ModifiedDate { get; set; }
        
        [DataMember(Name="country")]
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [DataMember(Name="region")]
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    }
}