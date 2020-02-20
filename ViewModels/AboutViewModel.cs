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
                MainViewModel.GlobalTitle = "Test";
                AboutTitle = "This change instantly... WHY??";

                // This forces Title to update from the default
                RaisePropertyChanged(nameof(Title));
                Validate();
            });

            MainViewModel.StaticPropertyChanged += (s,e) => { Validate(); };

            Validate();
        }

        public string Title
        {
            get { return MainViewModel.GlobalTitle; }
            set { MainViewModel.GlobalTitle = value; Validate(); }
        }


        private string _AboutTitle;
        public string AboutTitle
        {
            get { return _AboutTitle; }
            set { _AboutTitle = value; RaisePropertyChanged(nameof(AboutTitle)); }
        }


        void Validate()
        {
            ClearErrors(nameof(Title));

            if (string.IsNullOrWhiteSpace(Title))
            {
                AddError(nameof(Title), "Title should not be empty");
            }
            else if (Title == "Test")
            {
                AddError(nameof(Title), "You typed Test");
            }
        }


    }
}
