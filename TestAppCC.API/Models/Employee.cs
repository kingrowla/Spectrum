using System;
using Newtonsoft.Json;

namespace TestAppCC.API.Models
{
    public class Employee
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("first_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
    }
}

