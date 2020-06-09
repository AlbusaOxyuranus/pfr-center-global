using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PFRCenterGlobal.Models
{
    public class O2CCertificateForReturnDto
    {
        [JsonProperty(PropertyName = "id")] public Guid Id { get; set; }

        [JsonProperty(PropertyName = "serial")]
        public string Serial { get; set; }

        [JsonProperty(PropertyName = "shortNumber")]
        public int ShortNumber { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "education")]
        public string Education { get; set; }

        [JsonProperty(PropertyName = "dateOfCert")]
        public long? DateOfCert { get; set; }

        [JsonProperty(PropertyName = "visible")]
        public bool Visible { get; set; }

        [JsonProperty(PropertyName = "lock")] 
        public bool Lock { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        public long ModifiedDate { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "middlename")]
        public string Middlename { get; set; }

        //Todo: I have a one question. Maybe remove it? 
        [JsonProperty(PropertyName = "contacts")]
        public List<O2CContactDto> Contacts { get; set; } = new List<O2CContactDto>();
        //
        // [JsonProperty(PropertyName = "locations")]
        // public List<O2CLocationDto> Locations { get; set; } = new List<O2CLocationDto>();

        [JsonProperty(PropertyName = "photoUrl")]
        public string PhotoUrl { get; set; }

        [JsonProperty(PropertyName = "allContacts")]
        public string AllContacts { get; set; }

        [JsonProperty(PropertyName = "allLocations")]
        public string AllLocations { get; set; }
    }
}