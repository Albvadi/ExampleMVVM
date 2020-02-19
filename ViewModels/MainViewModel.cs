using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using System;
using System.ComponentModel;

namespace ExampleMVVM.ViewModels
{
    public class MainViewModel : PropertyChangedViewModel
    {
        // This is needed for static Properties to Update. Cannot be moved to BaseClass.
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        public static void RaiseStaticPropertyChanged(string PropertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(PropertyName));
        }

        public MainViewModel()
        {
            GlobalTitle = "Title from the MainViewModel constructor";
        }



        private static string _GlobalTitle;
        public static string GlobalTitle
        {
            get { return _GlobalTitle; }
            set { _GlobalTitle = value; RaiseStaticPropertyChanged(nameof(GlobalTitle)); }
        }

        public SettingsViewModel SettingsView { get; } = new SettingsViewModel();
        public AboutViewModel AboutView { get; } = new AboutViewModel();

    }
}
