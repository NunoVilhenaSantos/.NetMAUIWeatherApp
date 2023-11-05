using System.Diagnostics;
using Newtonsoft.Json;
using WeatherApp.Data;

namespace WeatherApp.Services;

/// <summary>
///
/// </summary>
public class RestService : IDisposable
{
    private readonly HttpClient _client;

    /// <summary>
    ///
    /// </summary>
    public RestService()
    {
        _client = new HttpClient();
    }


    /// <summary>
    ///
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<WeatherData> GetWeatherData(string query)
    {
        WeatherData weatherData = null;

        try
        {
            var response = await _client.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                weatherData =
                    JsonConvert.DeserializeObject<WeatherData>(content);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw;
        }

        return weatherData;
    }


    /// <inheritdoc />
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}