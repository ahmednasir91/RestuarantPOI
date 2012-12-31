using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestuarantPOI.Annotations;

namespace RestuarantPOI.Models
{
    public class Item : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _itemName;
        public string ItemName { get { return _itemName; } set { _itemName = value; OnPropertyChanged(); } }
        private decimal _price;
        public decimal Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }
        private string _image;
        private List<StockItem> _ingredients;
        public string Image { get { return _image; } set { _image = value; OnPropertyChanged(); } }

        public List<StockItem> Ingredients
        {
            get { return _ingredients = _ingredients ?? new List<StockItem>(); }
            set
            {
                if (Equals(value, _ingredients)) return;
                _ingredients = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
