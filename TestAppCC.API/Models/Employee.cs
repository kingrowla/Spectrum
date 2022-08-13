using System;
using System.Text.Json.Serialization;

namespace TestAppCC.API.Models
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }
    }
}

