using System.Linq;
using RestuarantPOI.Models;

namespace RestuarantPOI.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage
    {
        private readonly Order _order;

        public OrderPage()
        {
            InitializeComponent();
            _order = new Order();
            OrderGrid.DataContext = _order;
        }

        public void AddNewOrderItem(ItemSelectedArgs args)
        {
            if (_order.OrderStatus == OrderStatus.Closed) return;
            var item = args.Item;
            var existingItem = _order.OrderItems.SingleOrDefault(o => o.ItemName.Equals(item.ItemName));
            if (existingItem == null)
                _order.OrderItems.Add(new OrderItem(item.ItemName, item.Price));
            else
                existingItem.Quantity++;
        }
    }
}
