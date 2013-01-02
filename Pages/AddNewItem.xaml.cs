using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using RestuarantPOI.Models;

namespace RestuarantPOI.Pages
{
    /// <summary>
    /// Interaction logic for AddNewItem.xaml
    /// </summary>
    public partial class AddNewItem
    {
        private readonly Item _item;
        public AddNewItem(Item item = null)
        {
            InitializeComponent();
            _item = item ?? new Item();
            MainGrid.DataContext = _item;
            StockDataGrid.Columns[0].IsReadOnly = true;
            StockDataGrid.Columns[2].IsReadOnly = true;
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            ResetModel();
        }

        private void ResetModel()
        {
            _item.ItemName = String.Empty;
            _item.Image = String.Empty;
            _item.Price = 0;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            using (var ds = new DataStorage())
            {
                try
                {
                    ds.AddNewItem(_item);
                    ResetModel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while saving." + ex.Message, "Error");
                    return;
                }

                MessageBox.Show("Settings Saved!", "Info");
            }
        }

        private void ImageViewUpload_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter =
                    "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF",
            };
            if (!((bool)fileDialog.ShowDialog())) return;
            if (!Directory.Exists("Images/Items"))
                Directory.CreateDirectory("Images/Items");
            var fileName = DateTime.UtcNow.Ticks + Path.GetExtension(fileDialog.SafeFileName);
            File.Copy(fileDialog.FileName, "Images/Items/" + fileName, true);
            _item.Image = fileName;
        }

        private void NewIngredientList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NewIngredientDropDown.IsOpen = false;
            if (e.AddedItems.Count == 0)
                return;
            var itemName = e.AddedItems[0].ToString();
            _item.Ingredients.Add(new StockItem(itemName));
            using (var dataStorage = new DataStorage())
                _item.Ingredients.Last().Unit = dataStorage.StockItem(itemName).Unit;
            StockDataGrid.Focus();
            StockDataGrid.CurrentCell = new DataGridCellInfo(StockDataGrid.Items[StockDataGrid.Items.Count - 1], StockDataGrid.Columns[1]);
            StockDataGrid.BeginEdit();
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;
            using (var dataStorage = new DataStorage())
            {
                dataStorage.SaveItem(_item);
            }
            MessageBox.Show("Item has been saved successfully.", "Success");

        }

        private  bool Validate()
        {
            if (String.IsNullOrEmpty(_item.ItemName))
                Message("Item Name is empty.");
            else if(_item.ItemName.Equals("Item Name"))
                Message("Please edit the Item Name.");
            else if(_item.Price <= 0)
                Message("Please enter a price.");
            else
                return true;
            return false;
        }

        private static void Message(string message)
        {
            MessageBox.Show(message, "Error");
        }
    }
}
