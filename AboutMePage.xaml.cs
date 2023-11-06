using WeatherApp.Data;

namespace WeatherApp;

public partial class AboutMePage : ContentPage
{
    private readonly AuthorInfo _authorInfo;


    public AboutMePage()
    {
        InitializeComponent();

        _authorInfo = new AuthorInfo();

        BindingContext = _authorInfo;


        // Definir informações do autor
        // _authorInfo.Name = "Nome do Autor";
        // _authorInfo.Email = "email@autor.com";
        // _authorInfo.Email2 = "email@autor.com";
        // _authorInfo.Email3= "email@autor.com";
        // _authorInfo.Address= "morada do autor";
        // _authorInfo.MobilePhone= "telefone do autor";


        // Exibir informações do autor na página
        // AuthorNameLabel.Text = "Autor: " + _authorInfo.Name;
        // AuthorEmailLabel.Text = "E-mail: " + _authorInfo.Email;
        // AuthorEmail2Label.Text = "E-mail: " + _authorInfo.Email2;
        // AuthorEmail3Label.Text = "E-mail: " + _authorInfo.Email3;
        // AuthorAddressLabel.Text = "Address: " + _authorInfo.Address;
        // AuthorMobilePhoneLabel.Text = "MobilePhone: " + _authorInfo.MobilePhone;
    }
}