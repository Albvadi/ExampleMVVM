using ExampleMVVM.Base;

namespace ExampleMVVM.ViewModels
{
    public class AboutViewModel : PropertyChangedViewModel
    {
        private MainViewModel _mainViewModel;

        private string _aboutTitle;

        public DelegateCommand setTitleFromAbout { get; }

        public AboutViewModel(PropertyChangedViewModel mainViewModel)
        {
            _mainViewModel = (MainViewModel) mainViewModel;
            AboutTitle = "Initial About Title";

            setTitleFromAbout = new DelegateCommand(() =>
            {
                _mainViewModel.GlobalTitle = "Title setted from AboutView";
                AboutTitle = "This change instantly... WHY??";
            });
        }

        public string Title
        {
            get { return _mainViewModel.GlobalTitle; }
        }

        public string AboutTitle
        {
            get => _aboutTitle;
            set
            {
                _aboutTitle = value;
                OnPropertyChanged("aboutTitle");
            }
            //set => SetProperty(ref _globalTitle, value);
        }
    }
}
