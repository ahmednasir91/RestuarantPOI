using System.Windows;

namespace RestuarantPOI
{
	/// <summary>
	/// Interaction logic for HeaderButtonControl.xaml
	/// </summary>
	public partial class HeaderButtonControl
	{
	    public delegate void ClickHandler(object sender, RoutedEventArgs e); 
        public event ClickHandler Click;
	    public string Title { get { return ButtonTitle.Text; } set { ButtonTitle.Text = value; } }

		public HeaderButtonControl()
		{
			InitializeComponent();
		}

	    private void NewOrder_OnClick(object sender, RoutedEventArgs e)
	    {
	        if (Click != null)
	            Click("NewOrder", e);
	    }
	}
}