namespace ExampleMVVM.ViewModels
{
    public class HomeViewModel : PropertyChangedViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public HomeViewModel(PropertyChangedViewModel mainViewModel)
        {
            _mainViewModel = (MainViewModel)mainViewModel;
        }

        public string Title
        {
            get { return _mainViewModel.GlobalTitle; }
        }
    }
}
