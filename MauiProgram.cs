namespace WeatherApp;

/// <summary>
///
/// </summary>
public static class MauiProgram
{
    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            })
            //.ConfigureEssentials(essentials =>
            //{
            //    essentials.AddFileSystem();
            //    essentials.AddAppActions();
            //    essentials.AddClipboard();
            //    essentials.AddImageSourceHandlers();
            //    essentials.AddEmail();
            //    essentials.AddLauncher();
            //    essentials.AddMaps();
            //    essentials.AddPhoneDialer();
            //    essentials.AddPreferences();
            //    essentials.AddSms();
            //    essentials.AddVersionTracking();
            //    essentials.AddWebAuthenticator();
            //    essentials.AddWebP();
            //})
            ;


 
        return builder.Build();
    }


}