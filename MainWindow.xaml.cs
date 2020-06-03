using MahApps.Metro.Controls;

namespace ExampleMVVM
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            DataContext = new ViewModels.MainViewModel();
            InitializeComponent();
        }
    }
}
