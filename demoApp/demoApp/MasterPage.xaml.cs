using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{

	public partial class MasterPage : ContentPage
	{
		public MasterPage ()
		{
			InitializeComponent ();
		}

        private  void BtnHomePage_Clicked(object sender, EventArgs e)
        {
            ((MainPage)App.Current.MainPage).Detail = new NavigationPage(new HomeTabbedPage());
            

        }

        private  void BtnDashboardPage_Clicked(object sender, EventArgs e)
        {  var navigation = ((MainPage)App.Current.MainPage).Detail.Navigation;
            ((MainPage)App.Current.MainPage).IsPresented = false;
            navigation.PushAsync(new DashBoardTabbedPage());

            //var navigation = ((MainPage)App.Current.MainPage).Detail.Navigation;
            //((MainPage)App.Current.MainPage).IsPresented = false;
            //navigation.PushAsync(new DashBoard());
        }

        private  void BtnLoggerPage_Clicked(object sender, EventArgs e)
        {
            var navigation = ((MainPage)App.Current.MainPage).Detail.Navigation;
            ((MainPage)App.Current.MainPage).IsPresented = false;
            navigation.PushAsync(new LoggerPage());
        }

        private  void BtnAboutpage_Clicked(object sender, EventArgs e)
        {
            var navigation = ((MainPage)App.Current.MainPage).Detail.Navigation;
            ((MainPage)App.Current.MainPage).IsPresented = false;
            navigation.PushAsync(new AboutPage());
        }
    }
}