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
	public partial class Motor_status : ContentPage
	{
		public Motor_status ()
		{
			InitializeComponent ();
		}
        private void btnStart_Clicked(object sender, EventArgs e)
        {
            if(btnStart.Image=="start.png")
            {
                if(BindingContext is DataInformation information)
                {
                    information.SendEvent.Execute(1);
                }
            }
            else if(btnStart.Image=="Stop_new.png")
            {
                if (BindingContext is DataInformation information)
                {
                    information.SendEvent.Execute(0);
                }
            }
        }
    }
}