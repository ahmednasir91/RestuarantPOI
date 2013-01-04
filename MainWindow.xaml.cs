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
            NavigateToNewOrder();
        }

        private void NavigateToNewOrder()
        {
            var itemsList = new ItemsList();
            var orderPage = new OrderPage();
            itemsList.ItemSelected += (o, args) => orderPage.AddNewOrderItem(args);
            MainContentFrame.Navigate(itemsList);
            OrderFrame.Navigate(orderPage);
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
            NavigateToNewOrder();
        }

    }
}
