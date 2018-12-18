
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;

using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoard : ContentPage
    {
        private readonly List<Microcharts.Entry> _entries = new List<Microcharts.Entry>()
           {
               new Microcharts.Entry(0)
               {
                   Label="values",
                   ValueLabel="0",
                   Color=SKColor.Parse("#06572a")

               }
           };

        public DashBoard()
        {
            InitializeComponent();
            LineChartModel.Chart = new LineChart { Entries = _entries};
            PointChartModel.Chart = new PointChart { Entries = _entries};
            //aTimer = new Timer();
            //aTimer.Interval = 2000;
            //aTimer.Elapsed += ATimer_Elapsed;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;
        }

        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            float val = rm.Next(0, 100);
            txtData.Text = val.ToString();
            _entries.Add(new Microcharts.Entry(val) { ValueLabel = val.ToString(),Color=SKColor.Parse("#06572a") });
            Device.BeginInvokeOnMainThread(LineChartModel.InvalidateSurface);
            Device.BeginInvokeOnMainThread(PointChartModel.InvalidateSurface);
            
               
        }

      
        private static Timer aTimer;
        Random rm = new Random();
    }
}