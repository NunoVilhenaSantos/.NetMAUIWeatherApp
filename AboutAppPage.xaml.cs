using WeatherApp.Helpers;

namespace WeatherApp;

public partial class AboutAppPage : ContentPage
{
    public AboutAppPage()
    {
        InitializeComponent();

        // Obter e exibir a versão do aplicativo
        var appVersion = AppInfoHelper.GetVersion();


        // Obter informações sobre a aplicação
        var appInfo = AppInfo.BuildString;


        WelcomeLabel.Text = "Bem-vindo ao aplicativo de previsão do tempo!";

        AppFunctionsLabel.Text =
            "Este é um aplicativo de previsão do tempo simples.";

        AppBuildLabel.Text = "App Build: " + AppInfo.BuildString;

        AppVersionLabel.Text = "App Version: " + AppInfo.VersionString;

        AppCurrentLabel.Text = "App Current: " + AppInfo.Current;

        AppNameLabel.Text = "App Name: " + AppInfo.Name;
        AppPackageNameLabel.Text = "App Package Name: " + AppInfo.PackageName;
        AppPackagingModelLabel.Text =
            "App Packaging Model: " + AppInfo.PackagingModel;
    }
}