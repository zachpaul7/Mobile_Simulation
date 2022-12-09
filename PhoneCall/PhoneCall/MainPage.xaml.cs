using System.Xml.Linq;

namespace PhoneCall;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void Callbtn_Clicked(object sender, EventArgs e)
	{
		if (PhoneDialer.Default.IsSupported)
		{
			PhoneDialer.Default.Open(callLabel.Text.Trim());
		}
    }
}

