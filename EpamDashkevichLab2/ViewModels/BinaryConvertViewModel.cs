using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EpamDashkevichLab2.ViewModels
{

    class BinaryConvertViewModel : INotifyPropertyChanged
    {
        private int _Number;
        private string _Binary;
        public int Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
                OnPropertyChanged();
            }
        }
        public string Binary
        {
            get
            {
                return _Binary;
            }
            set
            {
                _Binary = value;
                OnPropertyChanged();
            }
        }
        public BinaryConvertViewModel()
        {
            Number = 0;
            ConvertToBinary = new Command(OnConvertToBinaryExecuted, CanConvertToBinaryExecute);
        }
        public ICommand ConvertToBinary { get; }
        public void OnConvertToBinaryExecuted(object parameter)
        {
            try
            {
                Binary = Converter.IntToBinary(Number);
            }
            catch (Exception e)
            {

            }
        }
        public bool CanConvertToBinaryExecute(object parameter)
        {
            if (Number >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
