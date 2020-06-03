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
