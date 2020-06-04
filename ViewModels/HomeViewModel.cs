using ExampleMVVM.Base;
using System.Threading.Tasks;

namespace ExampleMVVM.ViewModels
{
    public class HomeViewModel : PropertyChangedViewModel
    {
        public DelegateCommand SearchEmployeeAction { get; }

        private bool _IsSearching = false;
        public bool IsSearching
        {
            get { return _IsSearching; }
            set { _IsSearching = value; RaisePropertyChanged(nameof(IsSearching)); }
        }

        public HomeViewModel()
        {
            SearchEmployeeAction = new DelegateCommand(async (param) =>
            {
                IsSearching = true;

                await PutTaskDelay();

                IsSearching = false;

                // We have an async method. That means we may not recieve the updates to the UI. With the following line we tell 
                // the Command to do a Update on CanExecute. 
                SearchEmployeeAction.OnCanExecuteChanged();
            },
            (param) =>
            {
                return !IsSearching;
            });


            async Task PutTaskDelay()
            {
                await Task.Delay(3000);
            }
            
        }

    }
}
