using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestuarantPOI.Annotations;

namespace RestuarantPOI.Models
{
    internal class OrderItem : INotifyPropertyChanged
    {
        private decimal _price;
        private int _quantity;
        private string _itemName;
        private decimal _total;

        public OrderItem(string itemName, decimal price)
        {
            ItemName = itemName;
            Price = price;
            Quantity = 1;
        }

        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (value == _itemName) return;
                _itemName = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value == _quantity) return;
                _quantity = value;
                OnPropertyChanged();
                UpdateTotal();
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value == _price) return;
                _price = value;
                OnPropertyChanged();
                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            Total = Price*Quantity;
        }

        public decimal Total
        {
            get { return _total; }
            set
            {
                if (value == _total) return;
                _total = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}