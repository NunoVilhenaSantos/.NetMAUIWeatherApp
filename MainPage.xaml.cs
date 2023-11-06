

using WeatherApp.Data;
using WeatherApp.Helpers;
using WeatherApp.Services;

namespace WeatherApp;

/// <inheritdoc cref="Microsoft.Maui.Controls.ContentPage" />
public partial class MainPage : ContentPage, IDisposable
{
    private WeatherData _weatherData;
    private List<WeatherCities> _weatherCities;

    private readonly RestService _restService;
    private readonly FahrenheitCelsiusConverter _fahrenheitCelsiusConverter;

    // Variável para rastrear a unidade de temperatura
    private bool _isCelsius = true;


    /// <inheritdoc />
    public MainPage()
    {
        InitializeComponent();


        _fahrenheitCelsiusConverter = new FahrenheitCelsiusConverter();
        _restService = new RestService();
        _weatherData = new WeatherData();
        _weatherCities = new List<WeatherCities>();


        CityEntry.Text = "São Paulo";
        GetWeatherButton.Clicked += OnGetWeatherButtonClicked;


        // Agora, acione o evento manualmente
        OnGetWeatherButtonClicked(GetWeatherButton, EventArgs.Empty);
    }


    /// <inheritdoc />
    public void Dispose()
    {
        throw new NotImplementedException();
    }



    private void OpenAppShell_Clicked(object sender, EventArgs e)
    {
        // Navegue para o AppShell ou a página que contém o AppShell
        Navigation.PushAsync(new FlyoutPageDemo()); // Ou a página que contém o AppShell
    }




    private async void OnGetWeatherButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CityEntry.Text)) return;

        var weatherData = await
            _restService.GetWeatherData(
                GenerateRequestUrl(Constants.OpenWeatherMapEndpoint));

        _weatherData = weatherData;

        BindingContext = _weatherData;
    }


    private string GenerateRequestUrl(string endPoint)
    {
        var requestUri = endPoint;
        requestUri += $"?q={CityEntry.Text}";
        requestUri += "&units=imperial";
        requestUri += $"&APPID={Constants.OpenWeatherMapApiKey}";
        return requestUri;
    }


    private async void OnGetGeoCodingCitiesButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CityGeoCodingEntry.Text)) return;

        var weatherCities = await
            _restService.GetGeoCodingCitiesData(
                GenerateRequestUrlGeoCoding(Constants.OpenWeatherGeoEndpoint));

        _weatherCities = weatherCities;

        // Assuming weatherCities is a list of cities with a property CityName
        CityListView.ItemsSource = weatherCities;
        CityListView.IsVisible = true; // Show the list view
    }



    private string GenerateRequestUrlGeoCoding(string endPoint)
    {
        var requestUri = endPoint;
        requestUri += $"?q={CityGeoCodingEntry.Text}";
        requestUri += "&limit=5";
        requestUri += $"&APPID={Constants.OpenWeatherMapApiKey}";
        return requestUri;
    }


    private void OnCitySelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is WeatherCities selectedCity)
        {
            // Do something with the selected city, for example, display it in an Entry field.
            CityGeoCodingEntry.Text = selectedCity.Name;

            // Hide the list view again
            CityListView.IsVisible = false;
        }
    }



    private void OnCelsiusButtonClicked(object sender, EventArgs e)
    {
        // _isCelsius = true;
        // UpdateTemperatureDisplay();

        UpdateTemperatureDisplay("Celsius");
    }


    private void OnFahrenheitButtonClicked(object sender, EventArgs e)
    {
        // _isCelsius = false;
        // UpdateTemperatureDisplay();

        UpdateTemperatureDisplay("Fahrenheit");
    }


    private void OnKelvinButtonClicked(object sender, EventArgs e)
    {
        var fahrenheit = _weatherData.Main.Temperature;
        var kelvin = 0.00;

        if (!Equals(fahrenheit, null))
            kelvin = (fahrenheit - 32) * 5 / 9 + 273.15;

        TemperatureLabel.Text = $"{kelvin:N1}";

        CelsiusFahrenheitLabel.Text = " °K";

        UpdateTemperatureDisplay("Kelvin");
    }


    private void UpdateTemperatureDisplay()
    {
        var fahrenheit = _weatherData.Main.Temperature;
        var celsius = 0.00;

        if (!Equals(fahrenheit, null))
            celsius = (fahrenheit - 32) * 5 / 9;

        TemperatureLabel.Text = _isCelsius
            ? $"{celsius:N1}" // Exibir a temperatura em Celsius
            : $"{_weatherData.Main.Temperature:N1}"; // Exibir a temperatura em Fahrenheit

        CelsiusFahrenheitLabel.Text = _isCelsius ? " °C" : " °F";
    }


    private void UpdateTemperatureDisplay(string unit)
    {
        var fahrenheit = _weatherData.Main.Temperature;
        var temperature = fahrenheit;

        switch (unit)
        {
            case "Celsius":
                temperature = (fahrenheit - 32) * 5 / 9;
                CelsiusFahrenheitLabel.Text = " °C";
                break;
            case "Fahrenheit":
                CelsiusFahrenheitLabel.Text = " °F";
                break;
            case "Kelvin":
                temperature = (fahrenheit - 32) * 5 / 9 + 273.15;
                CelsiusFahrenheitLabel.Text = " °K";
                break;
        }

        TemperatureLabel.Text = $"{temperature:N1}";
    }


    private void OnAboutClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AboutPage());
    }


    /// <summary>
    ///
    /// </summary>
    public class MenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}