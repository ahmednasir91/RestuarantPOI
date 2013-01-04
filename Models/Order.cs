using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using RestuarantPOI.Annotations;

namespace RestuarantPOI.Models
{
    public enum OrderStatus
    {
        OnHold,
        Cancelled,
        Closed,
        Open,
    }

    class Order : INotifyPropertyChanged
    {
        private decimal _paidAmount;
        private decimal _discount;
        private decimal _totalPrice;
        private OrderStatus _orderStatus;
        private BindingList<OrderItem> _orderItems;
        private int? _id;

        public Order()
        {
            OrderItems = new BindingList<OrderItem>();
        }

        public BindingList<OrderItem> OrderItems
        {
            get
            {
                _orderItems.ListChanged += (sender, args) => TotalPrice = _orderItems.Sum(i => i.Total);
                return _orderItems;
            }
            set
            {
                if (Equals(value, _orderItems)) return;
                _orderItems = value;
                OnPropertyChanged();
            }
        }

        public OrderStatus OrderStatus
        {
            get { return _orderStatus; }
            set
            {
                if (value == _orderStatus) return;
                _orderStatus = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (value == _totalPrice) return;
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        public decimal Discount
        {
            get { return _discount; }
            set
            {
                if (value == _discount) return;
                _discount = value;
                OnPropertyChanged();
            }
        }

        public decimal PaidAmount
        {
            get { return _paidAmount; }
            set
            {
                if (value == _paidAmount) return;
                _paidAmount = value;
                OnPropertyChanged();
            }
        }

        public int? Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
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
