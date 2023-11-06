using Newtonsoft.Json;

namespace WeatherApp.Data;

/// <summary>
/// </summary>
public class WeatherData
{
    [JsonProperty("name")] public string Title { get; set; }

    [JsonProperty("coord")] public Coord Coord { get; set; }

    [JsonProperty("weather")] public Weather[] Weather { get; set; }

    [JsonProperty("base")] public string Base { get; set; }

    [JsonProperty("main")] public Main Main { get; set; }

    [JsonProperty("visibility")] public long Visibility { get; set; }

    [JsonProperty("wind")] public Wind Wind { get; set; }

    [JsonProperty("clouds")] public Clouds Clouds { get; set; }

    [JsonProperty("dt")] public long Dt { get; set; }

    [JsonProperty("sys")] public Sys Sys { get; set; }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("cod")] public long Cod { get; set; }
}

/// <summary>
/// </summary>
public class Clouds
{
    [JsonProperty("all")] public long All { get; set; }
}

/// <summary>
/// </summary>
public class Coord
{
    [JsonProperty("lon")] public double Lon { get; set; }

    [JsonProperty("lat")] public double Lat { get; set; }
}

/// <summary>
/// </summary>
public class Main
{
    [JsonProperty("temp")] public double Temperature { get; set; }

    [JsonProperty("pressure")] public long Pressure { get; set; }

    [JsonProperty("humidity")] public long Humidity { get; set; }

    [JsonProperty("temp_min")] public double TempMin { get; set; }

    [JsonProperty("temp_max")] public double TempMax { get; set; }
}

/// <summary>
/// </summary>
public class Sys
{
    [JsonProperty("type")] public long Type { get; set; }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("message")] public double Message { get; set; }

    [JsonProperty("country")] public string Country { get; set; }

    [JsonProperty("sunrise")] public long Sunrise { get; set; }

    [JsonProperty("sunset")] public long Sunset { get; set; }
}

/// <summary>
/// </summary>
public class Weather
{
    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("main")] public string Visibility { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("icon")] public string Icon { get; set; }
}

/// <summary>
/// </summary>
public class Wind
{
    [JsonProperty("speed")] public double Speed { get; set; }

    [JsonProperty("deg")] public long Deg { get; set; }
}