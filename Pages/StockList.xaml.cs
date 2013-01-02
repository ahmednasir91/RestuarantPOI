using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RestuarantPOI.Models;

namespace RestuarantPOI.Pages
{
    /// <summary>
    /// Interaction logic for StockList.xaml
    /// </summary>
    public partial class StockList
    {
        public BindingList<StockItem> StockItems;

        public StockList()
        {
            InitializeComponent();
        }


        private async void StockList_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var ds = await Task.Run(() => new DataStorage()))
            {
                StockItems = (BindingList<StockItem>) ds.StockItems();
            }
            StockDataGrid.DataContext = StockItems;
            StockDataGrid.ItemsSource = StockItems;
        }

        private void AddNew_OnClick(object sender, RoutedEventArgs e)
        {
            if ((StockItems.Count > 0 && StockItems.Last().IsValid) || StockItems.Count == 0)
            {
                StockItems.AddNew();
                StockDataGrid.Focus();
                StockDataGrid.CurrentCell = new DataGridCellInfo(StockDataGrid.Items[StockDataGrid.Items.Count - 1], StockDataGrid.Columns[0]);
                StockDataGrid.BeginEdit();
            }
        }

        
        private async void Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (StockItems.All(s => s.IsValid))
                using (var ds = await Task.Run(() => new DataStorage()))
                {
                    ds.SaveStock(StockItems);
                    MessageBox.Show("Items Saved Successfully!", "Success");
                }
            else
                MessageBox.Show("Please correct the error then try again.", "Error");
        }
    }
}
