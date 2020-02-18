using ExampleMVVM.Base;
using MahApps.Metro.Controls;
using System.Diagnostics;

namespace ExampleMVVM.ViewModels
{
    public class SettingsViewModel : PropertyChangedViewModel
    {
        private MainViewModel _mainViewModel;

        public DelegateCommand setTitleFromSettings { get; }
        public DelegateCommand disableHomeOption { get; }
        public DelegateCommand disableAboutOption { get; }
        public DelegateCommand enableAllOptions { get; }

        public SettingsViewModel(PropertyChangedViewModel mainViewModel)
        {
            _mainViewModel = (MainViewModel)mainViewModel;

            setTitleFromSettings = new DelegateCommand(() =>
            {
                _mainViewModel.GlobalTitle = "Title setted from SettingsView, GLOBAL MODE!!!";
            });

            disableHomeOption = new DelegateCommand(() =>
            {
                foreach (HamburgerMenuIconItem item in _mainViewModel.MenuItems) {
                    if (item.Label == "Home")
                    {
                        item.IsEnabled = false;
                    }
                }

            });

            disableAboutOption = new DelegateCommand(() =>
            {
                foreach (HamburgerMenuIconItem item in _mainViewModel.MenuItems)
                {
                    if (item.Label == "About")
                    {
                        item.IsEnabled = false;
                    }
                }

            });

            enableAllOptions = new DelegateCommand(() =>
            {
                foreach (HamburgerMenuIconItem item in _mainViewModel.MenuItems)
                {
                    item.IsEnabled = true;
                }

            });
        }
    }
}
