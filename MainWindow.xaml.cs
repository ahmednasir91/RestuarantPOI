using System.Windows;
using RestuarantPOI.Pages;

namespace RestuarantPOI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SourceInitialized += (o, args) => WindowState = WindowState.Maximized;
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ItemsList());
        }

        private void AddNewItem_OnClick(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new AddNewItem());
        }

        private void StockList_OnClick(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new StockList());
        }

        private void NewOrder_OnClick(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ItemsList());
        }
    }
}
