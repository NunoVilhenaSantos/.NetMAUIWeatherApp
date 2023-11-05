namespace WeatherApp;

/// <inheritdoc />
public partial class App : Application
{
    /// <inheritdoc />
    public App()
    {
        InitializeComponent();

        // MainPage = new MainPage();

        MainPage = new FlyoutPageDemo();
    
        // MainPage = new TabbedPageDemo();
    }

}