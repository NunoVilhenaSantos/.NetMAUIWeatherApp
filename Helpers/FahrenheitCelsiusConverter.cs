using System.Globalization;

namespace WeatherApp.Helpers;

/// <summary>
/// </summary>
public class FahrenheitCelsiusConverter : IValueConverter
{
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object Convert(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        var fahrenheit = (double) value;
        var celsius = 0.00;

        if (!Equals(fahrenheit, null))
            celsius = (fahrenheit - 32) * 5 / 9;

        return Math.Round(celsius).ToString(culture);
    }


    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object ConvertBack(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        var fahrenheit = 0.00;
        var celsius = (double) value;

        if (!Equals(celsius, null))
            fahrenheit = celsius * 9 / 5 + 32;

        return Math.Round(fahrenheit).ToString(culture);
    }
}