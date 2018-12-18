
using Xamarin.Forms;

namespace E_WELL
{

    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

        }

       

        private async void BtnConfiguration_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ConfigurationPage());
        }

        private async void BtnSettings_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SettingPage());
        }
    }
}