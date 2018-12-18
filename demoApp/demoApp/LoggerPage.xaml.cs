using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoggerPage : ContentPage
	{
        LoggerPageModel rm = new LoggerPageModel();
        public LoggerPage ()
		{
			InitializeComponent ();
            
        }

        private void BtnAddTest_Clicked(object sender, EventArgs e)
        {
            
            rm.Label = txtTextAdd.Text;
            BindingContext = rm;


        }
    }
}