using WeatherApp.Data;
using WeatherApp.Helpers;
using WeatherApp.Services;

namespace WeatherApp;

/// <inheritdoc cref="Microsoft.Maui.Controls.ContentPage" />
public partial class MainPage : ContentPage, IDisposable
{
    private readonly FahrenheitCelsiusConverter _fahrenheitCelsiusConverter;

    private readonly RestService _restService;


    // Variável para rastrear a unidade de temperatura
    private readonly bool _isCelsius = true;
    private List<WeatherCities> _weatherCities;
    private WeatherData _weatherData;
    private WeatherCities _selectedCity;

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
    void IDisposable.Dispose()
    {
    }


    private void OpenAppShell_Clicked(object sender, EventArgs e)
    {
        // Navegue para o AppShell ou a página que contém o AppShell
        // Ou a página que contém o AppShell
        Navigation.PushAsync(new FlyoutPageDemo());
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


    private async void OnGetGeoCodingCitiesButtonClicked(
        object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CityGeoCodingEntry.Text)) return;

        var weatherCities = await
            _restService.GetGeoCodingCitiesData(
                GenerateRequestUrlGeoCoding(Constants.OpenWeatherGeoEndpoint));

        _weatherCities = weatherCities;

        // Assuming weatherCities is a list of cities with a property CityName
        CityListView.ItemsSource = _weatherCities;

        // Show the list view
        CityListView.IsVisible = true;
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
        if (e.SelectedItem is not WeatherCities selectedCity) return;

        _selectedCity = selectedCity;


        // Do something with the selected city,
        // for example, display it in an Entry field.
        //CityGeoCodingEntry.Text = 
        //    selectedCity.Name + ", " + selectedCity.Country;

        CityEntry.Text =
            selectedCity.Name + ", " + selectedCity.Country;


        // Chamando o evento de clique do botão diretamente
        // OnGetWeatherButtonClicked(this, EventArgs.Empty);


        // Chamando o evento de clique do botão diretamente
        OnGetWeatherLatLonButtonClicked(this, EventArgs.Empty);


        // Hide the list view again
        CityListView.IsVisible = false;
    }


    private async void OnGetWeatherLatLonButtonClicked(object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CityEntry.Text)) return;

        var weatherData = await
            _restService.GetWeatherData(
                GenerateRequestUrlLatLon(Constants.OpenWeatherMapEndpoint));

        _weatherData = weatherData;

        BindingContext = _weatherData;
    }


    private string GenerateRequestUrlLatLon(string endPoint)
    {
        // https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid={API key}

        var requestUri = endPoint;
        requestUri += $"?lat={_selectedCity.Lat}&lon={_selectedCity.Lon}";
        requestUri += "&units=imperial";
        requestUri += $"&APPID={Constants.OpenWeatherMapApiKey}";
        return requestUri;
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
}