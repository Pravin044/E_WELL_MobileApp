﻿using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Xamarin.Forms;

namespace E_WELL
{
    public partial class MainPage : MasterDetailPage
    {
        MqttClient client;
        string DataRecived { get; set; }
        DataInformation data = new DataInformation();
        public MainPage()
        {
            InitializeComponent();
            Connect();
            Subscribe();
            if (client.IsConnected)
            {
                btnConnectToMqtt.Icon = "plugOut.png";
            }

        }

        private void Connect()
        {
            try
            {
                client = new MqttClient("broker.hivemq.com");

                if (client != null)
                {
                    DeviceConnected();
                    client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived; ;

                }
            }
            catch (Exception ex)
            {
                //Cursor = Cursors.Arrow;
                //DisplayAlert("Invalid HostName or Check your Connection", "Elpis OPC Server- MQTT Client", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Subscribe()
        {
            if (client.IsConnected)
            {
                client.Subscribe(new string[] { "E-well" /*string.Format("User.Connector1.Device1.{0}", TagName) */}, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            }
            else
            {
                DisplayAlert("E-WELL", "Unable to Connect Broker", "OK");
            }

        }

        private void DeviceConnected()
        {
            try
            {
                if (client.IsConnected)
                {
                    client.Disconnect();
                }

                byte code = client.Connect(Guid.NewGuid().ToString());

            }
            catch (Exception ex)
            {

            }
        }

        private void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            try
            {
                DataRecived = (Encoding.UTF8.GetString(e.Message)).ToString();
                data.WaterData = DataRecived.Split('/')[1];
                data.WaterLevel = DataRecived.Split('/')[1].Split('.')[1];
                data.WaterPressure = DataRecived.Split('/')[1].Split('.')[2];
                data.WaterFlow = DataRecived.Split('/')[1].Split('.')[3];
                data.MotorStatus = DataRecived.Split('/')[2].Split('.')[1];
                data.Voltage = DataRecived.Split('/')[2].Split('.')[2];
                data.MotorLoad = DataRecived.Split('/')[2].Split('.')[3];
                data.Current = DataRecived.Split('/')[2].Split('.')[4];
                data.CircuitData = DataRecived.Split('/')[3];
                BindingContext = data;
            }
            catch (Exception ex)
            {

            }

        }

        private void BtnConnectToMqtt_Clicked(object sender, EventArgs e)
        {
            if (btnConnectToMqtt.Icon == "plug_in.png")
            {
                Connect();
                Subscribe();
                if (client.IsConnected)
                {
                    btnConnectToMqtt.Icon = "plugOut.png";
                }
            }
            else if (btnConnectToMqtt.Icon == "plugOut.png")
            {
                DisconnectDevice();
                if(client.IsConnected)
                {
                    btnConnectToMqtt.Icon = "plug_in.png";
                }
            }
        }

        private void DisconnectDevice()
        {
            try
            {
                client.Disconnect();

            }
            catch (Exception ex) { }
        }
    }
}
