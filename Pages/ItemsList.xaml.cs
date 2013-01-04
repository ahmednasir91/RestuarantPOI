using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RestuarantPOI.Models;

namespace RestuarantPOI.Pages
{
    /// <summary>
    /// Interaction logic for ItemsList.xaml
    /// </summary>
    public partial class ItemsList
    {
        public event ItemSelected ItemSelected;
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

            if (ItemsListBox.SelectedItem == null || NavigationService == null)
                return;
            NavigationService.Navigate(new AddNewItem(ItemsListBox.SelectedItem as Item));
        }

        private void ItemsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            OnItemSelected(new ItemSelectedArgs(ItemsListBox.SelectedItem as Item));
            ItemsListBox.SelectedItem = null;
        }

        protected virtual void OnItemSelected(ItemSelectedArgs args)
        {
            var handler = ItemSelected;
            if (handler != null) handler(this, args);
        }

    }

    public delegate void ItemSelected(object sender, ItemSelectedArgs args);

    public class ItemSelectedArgs
    {
        public ItemSelectedArgs(Item item)
        {
            Item = item;
        }

        public Item Item { get; set; }
    }
}
