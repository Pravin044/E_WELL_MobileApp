using System;
using System.IO;
using System.Text;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedPage : TabbedPage
    {
        public string strFilePath { get; private set; }
        StringBuilder logData = new StringBuilder();
        private Timer aTimer;
        DataInformation data = new DataInformation();

        public HomeTabbedPage()
        {
            InitializeComponent();
            Children.Add(new Motor_status());
            Children.Add(new Water_Status());
            Children.Add(new Circuit_status());

        }


        private async void BtnConfiguration_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ConfigurationPage());
        }

        private async void BtnSettings_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SettingPage());
        }

        private void BtnRecordData_Clicked(object sender, EventArgs e)
        {
                if (btnRecordData.Icon == "recordicon.png")
                {
                    btnRecordData.Icon = "Stop.png";
                    DateTime TimeStamp = DateTime.Now;
                    string fileName = "E_well_" + TimeStamp.ToString().Replace(" ", "_").Replace(":", "_").Replace("/", "_") + ".csv";
                    strFilePath = @"/storage/emulated/0/EWell/LogData/" + fileName;
                    logData.AppendLine("Date Time,Motor Status,volatge,Current,MotorLoad,WaterLevel,WaterPressure,WaterFlow,First Fuse,Second Fuse,Third Fuse");
                    ReadTimer();


                }
                else if (btnRecordData.Icon == "Stop.png")
                {
                    btnRecordData.Icon = "recordicon.png";
                    File.AppendAllText(strFilePath, logData.ToString());
                    logData.Clear();
                    aTimer.Stop();
                }
           
           
        }

        private void ReadTimer()
        {
            aTimer = new Timer();
            aTimer.Interval = 1000;
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            data = (BindingContext) as DataInformation;

        }
        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            logData.AppendLine(DateTime.Now.ToString() + "," + data.MotorStatus + "," + data.Voltage + "," + data.Current + "," + data.MotorLoad + "," + data.WaterLevel + "," + data.WaterPressure + "," + data.WaterFlow + "," + data.FuseOneStatus + "," + data.FuseTwoStatus + "," + data.FuseThreeStatus);
            
        }
    }
}