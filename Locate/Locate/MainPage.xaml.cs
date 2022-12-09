using Microsoft.Maui.Devices.Sensors;
using System.Collections;
using System.Linq;
using Map = Microsoft.Maui.ApplicationModel.Map;

namespace Locate;

public partial class MainPage : ContentPage
{
    string loc_data = null;
    public double ld1;
    public double ld2;
    public MainPage()
	{
		InitializeComponent();
	}

	private async void BrowserBtn_Clicked(object sender, EventArgs e)
	{
        try
        {
            string url = urlData.Text;
            if (IsValidUrl(url))
            {
                Uri uri = new Uri(url);
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            else
            {
                await DisplayAlert("Alert", $"{url} is not a valid address.", "OK");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private bool IsValidUrl(string address)
    {
        return Uri.IsWellFormedUriString(address, UriKind.RelativeOrAbsolute);
    }

    private async void LocationBtn_Clicked(object sender, EventArgs e)
	{
        MapLaunchOptions option;

        loc_data = locData.Text;
        string[] locdata = loc_data.Split(',');
        
        if (locdata[0].Contains('-'))
        {
            locdata[0] = locdata[0].Replace("-",null);
            ld1 = double.Parse(locdata[0]) * -1;

            if (locdata[1].Contains('-'))
            {
                locdata[1] = locdata[1].Replace("-", null);
                
                ld2 = double.Parse(locdata[1]) * -1;
            }
            else
            {
                ld2 = double.Parse(locdata[1]);
            }
        }

        else
        {
            ld1 = double.Parse(locdata[0]);

            if (locdata[1].Contains('-'))
            {
                locdata[1] = locdata[1].Replace("-", null);

                ld2 = double.Parse(locdata[1]) * -1;
            }
            else
            {
                ld2 = double.Parse(locdata[1]);
            }  
        }

        IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(ld1, ld2);
        Placemark placemark = placemarks?.FirstOrDefault();

        var location = new Location(ld1,ld2);
        if(placemark != null)
        {
            option = new MapLaunchOptions { Name = placemark.CountryCode + ", " + placemark.AdminArea + ", " + placemark.Locality + ", " + placemark.Thoroughfare };
        }
        else
        {
            option = new MapLaunchOptions { Name = null };
        }

		await Map.Default.OpenAsync(location,option);

	}

}

