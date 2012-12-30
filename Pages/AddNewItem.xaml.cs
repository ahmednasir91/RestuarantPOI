using System;
using System.IO;
using System.Windows;
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
        public AddNewItem()
        {
            InitializeComponent();
            _item = new Item();
            MainGrid.DataContext = _item;
        }


        private void ImageUpload_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
                                 {
                                     Filter =
                                         "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF",
                                 };
            if (!((bool) fileDialog.ShowDialog())) return;
            if (!Directory.Exists("Images/Items"))
                Directory.CreateDirectory("Images/Items");
            File.Copy(fileDialog.FileName, "Images/Items/" + fileDialog.SafeFileName);
            _item.Image = fileDialog.SafeFileName;
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
    }
}
