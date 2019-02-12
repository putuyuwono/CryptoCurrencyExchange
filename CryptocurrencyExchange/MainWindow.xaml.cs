using System.Windows;

namespace CryptocurrencyExchange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            DataContext = vm;
            GetAssemblyVersion();
        }

        private void GetAssemblyVersion()
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Title += " v" + version;
        }

        private void btRefresh_Click(object sender, RoutedEventArgs e)
        {
            vm.Refresh();
        }
    }
}
