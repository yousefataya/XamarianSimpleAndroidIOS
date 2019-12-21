using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Abstractions.DataTransferObjects
{
    public class SelectRolePageDto
    {

        [JsonProperty("PersonName")]
        public string PersonName { get; set; }

        [JsonProperty("MobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

    }
}
