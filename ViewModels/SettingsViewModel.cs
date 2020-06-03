using ExampleMVVM.Base;
using MahApps.Metro.Controls;
using System.Diagnostics;

namespace ExampleMVVM.ViewModels
{
    public class SettingsViewModel : PropertyChangedViewModel
    {
        private bool _HomeEnabled = true;
        public bool HomeEnabled
        {
            get { return _HomeEnabled; }
            set { _HomeEnabled = value; RaisePropertyChanged(nameof(HomeEnabled)); }
        }

        private bool _AboutEnabled = true;
        public bool AboutEnabled
        {
            get { return _AboutEnabled; }
            set { _AboutEnabled = value; RaisePropertyChanged(nameof(AboutEnabled)); }
        }

     
        public DelegateCommand EnableAllOptions { get; }

        public SettingsViewModel()
        {
            EnableAllOptions = new DelegateCommand((param) =>
            {
                HomeEnabled = true;
                AboutEnabled = true;
            },
            (param) =>
            {
                return !HomeEnabled || !AboutEnabled;
            });
        }
    }
}
