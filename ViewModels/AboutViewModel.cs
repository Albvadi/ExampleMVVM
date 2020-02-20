using ExampleMVVM.Base;

namespace ExampleMVVM.ViewModels
{
    public class AboutViewModel : PropertyChangedViewModel
    {
        public DelegateCommand SetTitleFromAbout { get; }

        public AboutViewModel()
        {
            AboutTitle = "Initial About Title";

            SetTitleFromAbout = new DelegateCommand((param) =>
            {
                MainViewModel.GlobalTitle = "Title setted from AboutView";
                AboutTitle = "This change instantly... WHY??";

                // This forces Title to update from the default
                RaisePropertyChanged(nameof(Title));
            });


        }

        public string Title => MainViewModel.GlobalTitle;


        private string _AboutTitle;
        public string AboutTitle
        {
            get { return _AboutTitle; }
            set { _AboutTitle = value; RaisePropertyChanged(nameof(AboutTitle)); }
        }


    }
}
