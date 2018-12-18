using System;
using System.Globalization;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Circuit_status : ContentPage
    {
       
        public Circuit_status()
        {
            InitializeComponent();
                 
        }
        

       
    }

    internal class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string status)
            {
                switch (status)
                {
                    case "GOOD":
                        return Color.Green;
                }
            }
            return Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}