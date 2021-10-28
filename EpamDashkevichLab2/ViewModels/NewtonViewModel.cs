using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EpamDashkevichLab2.ViewModels
{
    class NewtonViewModel : INotifyPropertyChanged
    {
        private int _RootBase;
        private double _Number;
        private int _PrecisionPower;
        private double _Approximation;
        private string _NewtonRoot;
        private string _Root;
        public int RootBase
        {
            get
            {
                return _RootBase;
            }
            set
            {
                _RootBase = value;
                Approximation = MyMath.DemoApproximation(RootBase, Number);
                OnPropertyChanged();
            }
        }
        public double Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
                Approximation = MyMath.DemoApproximation(RootBase, Number);
                OnPropertyChanged();
            }
        }
        public int PrecisionPower
        {
            get
            {
                return _PrecisionPower;
            }
            set
            {
                _PrecisionPower = value;
                OnPropertyChanged();
            }
        }       
        public double Approximation
        {
            get
            {
                return _Approximation;
            }
            set
            {
                _Approximation = value;
                OnPropertyChanged();
            }
        }
        public string NewtonRoot
        {
            get
            {
                return _NewtonRoot;
            }
            set
            {
                _NewtonRoot = value;
                OnPropertyChanged();
            }
        }
        public string Root
        {
            get
            {
                return _Root;
            }
            set
            {
                _Root = value;
                OnPropertyChanged();
            }
        }
        public NewtonViewModel()
        {
            RootBase = 2;
            Number = 9;
            PrecisionPower = -6;
            Approximation = MyMath.DemoApproximation(RootBase, Number);
            CalculateRoot = new Command(OnCalculateRootExecuted, CanCalculateRootExecute); 
        }
        #region commands

        public ICommand CalculateRoot { get; }
        public void OnCalculateRootExecuted(object parameter)
        {
            try
            {
                NewtonRoot = MyMath.FindRootNewton(RootBase, Number, Approximation, PrecisionPower).ToString();
                Root = Math.Pow(Number, 1 / (double)RootBase).ToString();
            }
            catch (Exception e)
            {

            }
        }
        public bool CanCalculateRootExecute(object parameter)
        {
            if (RootBase != 0 && Number >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        #endregion

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
