using System;
using System.IO;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private void BtnTheam_Toggled(object sender, ToggledEventArgs e)
        {

            if (btnTheam.IsToggled == true)
            {
                Application.Current.Resources["backgroundColor"] = Color.Black;
                Application.Current.Resources["textColor"] = Color.White;
            }
            if (btnTheam.IsToggled == false)
            {
                Application.Current.Resources["backgroundColor"] = Color.White;
                Application.Current.Resources["textColor"] = Color.Black;
            }
        }

        private void SaveSettings_clicked(object sender, EventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(path, "Setting.xml");
            using (XmlWriter writer = XmlWriter.Create(filename))
            {
                writer.WriteStartElement("Setting");
                writer.WriteElementString("TextColor", txtTextName.Text);
                writer.WriteElementString("TheamColor", btnTheam.IsToggled.ToString());
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }

            DisplayAlert("Information", string.Format("File Saved ! Path;{0}", filename), "OK");

        }

    }
}