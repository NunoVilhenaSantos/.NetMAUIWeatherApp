
using WeatherApp.Helpers;

namespace WeatherApp;


public partial class AboutAppPage : ContentPage
{


    public AboutAppPage()
    {
        InitializeComponent();

        // Obter e exibir a vers�o do aplicativo
        string appVersion = AppInfoHelper.GetVersion();


        // Obter informa��es sobre a aplica��o
        var appInfo = AppInfo.BuildString;

        
        WelcomeLabel.Text = "Bem-vindo ao aplicativo de previs�o do tempo!";

        AppFunctionsLabel.Text = "Este � um aplicativo de previs�o do tempo simples.";
        
        AppBuildLabel.Text = "App Build: " + AppInfo.BuildString;

        AppVersionLabel.Text = "App Version: " + AppInfo.VersionString;

        AppCurrentLabel.Text = "App Current: " + AppInfo.Current;

        AppNameLabel.Text = "App Name: " + AppInfo.Name;
        AppPackageNameLabel.Text = "App Package Name: " + AppInfo.PackageName;
        AppPackagingModelLabel.Text = "App Packaging Model: " + AppInfo.PackagingModel;

    }

}