using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PFRCenterGlobal.Models
{
    [DataContract]
    public class O2CContactDto
    {
        [DataMember(Name="key")] 
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [DataMember(Name="value")]
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}