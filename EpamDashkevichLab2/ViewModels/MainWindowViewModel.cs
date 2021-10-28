using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace EpamDashkevichLab2.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Page _Newton;
        private Page _BinaryConvert;
        private Page _CurrentPage;

        public Page CurrentPage
        {
            get
            {
                return _CurrentPage;
            }
            set
            {
                _CurrentPage = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            _Newton = new Pages.Newton();
            _BinaryConvert = new Pages.BinaryConvert();
            CurrentPage = _Newton;
            GoNewton = new Command(OnGoNewtonExecuted, CanGoNewtonExecute);
            GoBinaryConvert = new Command(OnGoBinaryConvertExecuted, CanGoBinaryConvertExecute);

           // _BinaryConvert = new Pages.BinaryConvert();
        }
        public ICommand GoNewton { get; }
        
        public void OnGoNewtonExecuted(object parameter)
        {
            CurrentPage = _Newton;
        }
        public bool CanGoNewtonExecute(object parameter)
        {
            if (CurrentPage == _Newton)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public ICommand GoBinaryConvert { get; }

        public void OnGoBinaryConvertExecuted(object parameter)
        {
            CurrentPage = _BinaryConvert;
        }
        public bool CanGoBinaryConvertExecute(object parameter)
        {
            if (CurrentPage == _BinaryConvert)
            {
                return false;
            }
            else
            {
                return true;
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
