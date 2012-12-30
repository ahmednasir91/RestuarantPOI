using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using RestuarantPOI.Annotations;

namespace RestuarantPOI.Models
{
    public enum Unit
    {
        Kg,
        gm,
        Piece,
        Ltr,
    }

    public class StockItem : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _itemName;
        private decimal _quantity;
        private Unit _unit;
        private readonly Dictionary<string, bool> errorDictionary = new Dictionary<string, bool>();
        private bool _isValid;
        public bool isValid
        {
            get { return _isValid; }
            set
            {
                if (value.Equals(_isValid)) return;
                _isValid = value;
                OnPropertyChanged();
            }
        }

        public int Id { get; set; }
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

        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                if (value == _quantity) return;
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public Unit Unit
        {
            get { return _unit; }
            set
            {
                if (value == _unit) return;
                _unit = value;
                OnPropertyChanged();
            }
        }

        public string this[string columnName]
        {
            get
            {
                errorDictionary[columnName] = true;
                isValid = false;
                if (columnName.Equals("ItemName"))
                {
                    if (string.IsNullOrEmpty(ItemName))
                        return "Please enter a Item Name";
                    if (ItemName.Length > 15)
                        return "The Item Name length cannot be more than 15 characters.";
                }
                else if (columnName.Equals("Quantity"))
                {
                    if (Quantity < 0)
                        return "Please enter a quantity greater than 0";
                }
                errorDictionary[columnName] = false;
                isValid = errorDictionary.All(kv => !kv.Value);
                return string.Empty;
            }
        }

        public string Error
        {
            get
            {
                StringBuilder error = new StringBuilder();
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
                foreach (PropertyDescriptor prop in props)
                {
                    String propertyError = this[prop.Name];
                    if (propertyError != string.Empty)
                    {
                        error.Append((error.Length != 0 ? ", " : "") + propertyError);
                    }
                }

                return error.Length == 0 ? null : error.ToString();
            }
        }        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
