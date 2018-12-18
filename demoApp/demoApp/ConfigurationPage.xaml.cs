using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurationPage : ContentPage
    {
        List<string> itemlist = new List<string>();
        DataInformation data = new DataInformation();
        private FileData file;
        ConfigurationModel ConfigurationModel = new ConfigurationModel();
        ObservableCollection<ConfigurationModel> list = new ObservableCollection<ConfigurationModel>();
        string path = @"/storage/emulated/0/EWell/";
        public ConfigurationPage()
        {

            InitializeComponent();
            loadConfiguration();
        }

        private void loadConfiguration()
        {
            listView.ItemsSource = null;
            list.Clear();
            listView.ItemsSource = list;

            string filename = Path.Combine(path, "Configuration.xml");
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            if (fs.Length > 0)
            {
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("Configuration");
                for (int i = 0; i < 4; i++)
                {
                    list.Add(new ConfigurationModel { Title = xmlnode[0].ChildNodes.Item(i).Name, Subtitle = xmlnode[0].ChildNodes.Item(i).InnerText });
                }
            }

        }

        private void BtnSaveConfig_Clicked(object sender, EventArgs e)
        {
            try
            {

                data.Path = file.FilePath.Replace(file.FileName, "");
                var filename = Path.Combine(data.Path, "Configuration.xml");
                using (XmlWriter writer = XmlWriter.Create(filename))
                {
                    writer.WriteStartElement("Configuration");
                    foreach (var item in listView.ItemsSource)
                    {
                        var value = item as ConfigurationModel;
                        writer.WriteElementString(value.Title, value.Subtitle);

                    }
                    writer.WriteEndElement();
                    writer.Flush();

                }


                if (filename.Length > 0)
                {
                    DisplayAlert("Information", "File saved", "OK");
                }

            }
            catch (Exception ex) { }


        }

        private async void BtnImportConfig_Clicked(object sender, EventArgs e)
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file.FilePath != null)
                {
                    if (file.FileName.Contains(".xml"))
                    {
                        listView.ItemsSource = null;
                        list.Clear();
                        listView.ItemsSource = list;
                        XmlDocument xmldoc = new XmlDocument();
                        XmlNodeList xmlnode;
                        FileStream fs = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read);
                        if (fs.Length > 0)
                        {
                            xmldoc.Load(fs);
                            xmlnode = xmldoc.GetElementsByTagName("Configuration");
                            for (int i = 0; i < 4; i++)
                            {
                                list.Add(new ConfigurationModel { Title = xmlnode[0].ChildNodes.Item(i).Name, Subtitle = xmlnode[0].ChildNodes.Item(i).InnerText });
                            }
                        }
                    }
                    else
                    {
                       await DisplayAlert("E_WELL", "Invalid file","OK");
                    }

                }

            }
            catch (Exception ex) { }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var value = listView.SelectedItem as ConfigurationModel;
            PopupNavigation.Instance.PushAsync(new Popup(value.Title,value.Subtitle));

        }

        //private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (txtName.IsFocused == true)
        //    {
        //        var match = Regex.Match(txtName.Text, @"\w{1,10}$");
        //        if (match.Value != txtName.Text)
        //        {
        //            txtName.TextColor = Color.Red;
        //            lblNameValidation.Text = "*Incorrect format";
        //        }
        //        else
        //        {
        //            txtName.TextColor = Color.Black;
        //            lblNameValidation.Text = "";
        //        }
        //    }
        //    if (txtMobileNumber.IsFocused == true)
        //    {
        //        var match = Regex.Match(txtMobileNumber.Text, @"\d[0-9]{0,10}");
        //        if (match.Value != txtMobileNumber.Text)
        //        {
        //            txtMobileNumber.TextColor = Color.Red;
        //            lblMobileNumberValidation.Text = "*Incorrect format ! Enter digits";

        //        }
        //        else
        //        {
        //            txtMobileNumber.TextColor = Color.Black;
        //            lblMobileNumberValidation.Text = "";
        //        }
        //    }
        //    if (txtEmail.IsFocused == true)
        //    {
        //        var macth = Regex.Match(txtEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        //        if (macth.Value != txtEmail.Text)
        //        {
        //            txtEmail.TextColor = Color.Red;
        //            lblEmailValidation.Text = "*Enter valid email format";
        //        }
        //        else
        //        {
        //            txtEmail.TextColor = Color.Black;
        //            lblEmailValidation.Text = "";
        //        }

        //    }


        // }
    }
}