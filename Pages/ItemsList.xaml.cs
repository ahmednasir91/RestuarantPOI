using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using RestuarantPOI.Models;

namespace RestuarantPOI.Pages
{
    /// <summary>
    /// Interaction logic for ItemsList.xaml
    /// </summary>
    public partial class ItemsList
    {
        private IList<Item> itemsList; 
        public ItemsList()
        {
            InitializeComponent();
        }


        private async void ItemsList_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var ds = await Task.Run(() => new DataStorage()))
            {
                itemsList = ds.Items();
            }
            ItemsListBox.ItemsSource = itemsList;
        }
    }
}
