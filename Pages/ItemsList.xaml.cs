using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestuarantPOI.Models;

namespace RestuarantPOI.Pages
{
    /// <summary>
    /// Interaction logic for ItemsList.xaml
    /// </summary>
    public partial class ItemsList
    {
        private IList<Item> _itemsList; 
        public ItemsList()
        {
            InitializeComponent();
        }


        private async void ItemsList_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var ds = await Task.Run(() => new DataStorage()))
            {
                _itemsList = ds.Items();
            }
            ItemsListBox.ItemsSource = _itemsList;
        }

        private void ItemsListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (ItemsListBox.SelectedItem != null)
                NavigationService.Navigate(new AddNewItem(ItemsListBox.SelectedItem as Item));
        }
    }
}
