using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Popup : PopupPage
    {
        ConfigurationModel ConfigurationModel = new ConfigurationModel();
        ObservableCollection<ConfigurationModel> list = new ObservableCollection<ConfigurationModel>();
        ConfigurationPage cf = new ConfigurationPage();
        public Popup (string title,string subtitle)
		{
			InitializeComponent ();
            lblTitle.Text = title;
            entSubtitle.Text = subtitle;
		}

        private void Ok_Cliked(object sender, EventArgs e)
        {
            var entry = entSubtitle.Text;
            
            PopupNavigation.Instance.PopAsync(true);


        }

        private void Cancel_Cliked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }
    }
}