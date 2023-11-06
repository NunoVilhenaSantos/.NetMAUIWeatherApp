using System.Globalization;

namespace WeatherApp.Helpers;

/// <summary>
/// </summary>
public class LongToDateTimeConverter : IValueConverter
{
    private readonly DateTime _time = new(1970, 1, 1, 0, 0, 0, 0);


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
        var dateTime = (long) value;

        return $"{_time.AddSeconds(dateTime).ToString(culture)} UTC";
    }


    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public object ConvertBack(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not string stringValue)
            throw new ArgumentException(
                "O valor de entrada não pôde ser convertido para DateTime.");

        if (!DateTime.TryParse(stringValue, culture,
                DateTimeStyles.AssumeUniversal, out var dateTime))
            throw new ArgumentException(
                "O valor de entrada não pôde ser convertido para DateTime.");

        var timeDifference = dateTime - _time;

        return (long) timeDifference.TotalSeconds;
    }
}