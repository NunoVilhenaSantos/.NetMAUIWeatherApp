﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class WeatherCities
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("local_names", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> LocalNames { get; set; }

        [JsonProperty("lat")]
        public decimal Lat { get; set; }

        [JsonProperty("lon")]
        public decimal Lon { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }


    }
}
