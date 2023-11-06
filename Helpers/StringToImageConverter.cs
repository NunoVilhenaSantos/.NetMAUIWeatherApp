using System.Globalization;

namespace WeatherApp.Helpers;

internal class StringToImageConverter : IValueConverter
{
    // How to get icon URL
    // For code 500 - light rain icon = "10d". See below a full list of codes
    // URL is https://openweathermap.org/img/wn/10d@2x.png


    // string urlPrefix = "https://openweathermap.org/img/wn/";


    public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
    {
        var icon = (string) value;

        return Constants.IconUrlPrefix + icon + "@2x.png";
    }


    public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}