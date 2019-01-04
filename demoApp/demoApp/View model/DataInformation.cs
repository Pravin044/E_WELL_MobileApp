using System.ComponentModel;
using System.Windows.Input;

namespace E_WELL
{
    class DataInformation : INotifyPropertyChanged
    {
        private string _motorStatus = "Started";
        private string _waterData = "0";
        private string _circuitData = "0";
        private string _fuseOneStatus = "BAD";
        private string _fuseTwoStatus = "BAD";
        private string _fuseThreeStatus = "BAD";
        private string _voltage = "0";
        private string _currentMotorStatus = "1";
        private string _current = "0";
        private string _motorLoad = "0";
        private string _path;
        private string _motoStatusIcon = "Stop_new.png";
        private string _waterLevel = "0";
        private string _waterPressure = "0";
        private string _waterFlow = "0";

        public string MotorStatus
        {
            get
            {
                return _motorStatus;
            }
            set
            {
                if (_currentMotorStatus != value)
                {
                    _currentMotorStatus = value;
                    if (value == "1")
                    {
                        value = "Running";
                        MotoStatusIcon = "Stop_new.png";
                    }
                    else
                    {
                        value = "Stoped";
                        MotoStatusIcon = "start.png";
                    }
                    _motorStatus = value;
                    OnPropertyChanged(nameof(MotorStatus));
                }
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        public string WaterLevel
        {
            get => _waterLevel;
            set
            {
                _waterLevel = value;
                OnPropertyChanged(nameof(WaterLevel));
            }
        }

        public string WaterPressure
        {
            get => _waterPressure;
            set
            {
                _waterPressure = value;
                OnPropertyChanged(nameof(WaterPressure));
            }
        }

        public string WaterFlow
        {
            get { return _waterFlow; }
            set
            {
                _waterFlow = value;
                OnPropertyChanged(nameof(WaterFlow));
            }
        }

        public string Voltage
        {
            get { return _voltage; }
            set
            {
                _voltage = value;
                OnPropertyChanged(nameof(Voltage));
            }
        }

        public string Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged(nameof(Current));

            }
        }

        public string MotorLoad
        {
            get { return _motorLoad; }
            set
            {
                _motorLoad = value;
                OnPropertyChanged(nameof(MotorLoad));
            }
        }


        public string WaterData
        {
            get { return _waterData; }
            set
            {
                _waterData = value;
                OnPropertyChanged(nameof(WaterData));
            }
        }
        public string CircuitData
        {
            get
            {


                return _circuitData;

            }
            set
            {
                _circuitData = value;
                OnPropertyChanged(nameof(CircuitData));

                if (_circuitData.Split(',')[1] == "1")
                {
                    FuseOneStatus = "GOOD";
                }
                else
                {
                    FuseOneStatus = "BAD";
                }
                if (_circuitData.Split(',')[2] == "1")
                {
                    FuseTwoStatus = "GOOD";
                }
                else
                {
                    FuseTwoStatus = "BAD";
                }
                if (_circuitData.Split(',')[3] == "1")
                {
                    FuseThreeStatus = "GOOD";
                }
                else
                {
                    FuseThreeStatus = "BAD";
                }
            }
        }

        public string FuseOneStatus
        {
            get { return _fuseOneStatus; }
            set
            {
                _fuseOneStatus = value;
                OnPropertyChanged(nameof(FuseOneStatus));
            }
        }
        public string FuseTwoStatus
        {
            get { return _fuseTwoStatus; }
            set
            {
                _fuseTwoStatus = value;
                OnPropertyChanged(nameof(FuseTwoStatus));
            }
        }
        public string FuseThreeStatus
        {
            get { return _fuseThreeStatus; }
            set
            {
                _fuseThreeStatus = value;
                OnPropertyChanged(nameof(FuseThreeStatus));
            }
        }

        public ICommand SendEvent { get; set; }
        public string MotoStatusIcon
        {
            get => _motoStatusIcon; set
            {
                _motoStatusIcon = value;
                OnPropertyChanged(nameof(MotoStatusIcon));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
