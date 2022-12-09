namespace BaroSensor;

public partial class MainPage : ContentPage
{
	IBarometer barometer = Barometer.Default;

	public MainPage()
	{
		InitializeComponent();
	}

	private void Startbtn_Clicked(object sender, EventArgs e)
	{
		barometer.ReadingChanged += Barometer_ReadingChanged;
		barometer.Start(SensorSpeed.UI);
		Startbtn.IsEnabled = false;
		Stopbtn.IsEnabled = true;
	}


	private void Stopbtn_Clicked(object sender, EventArgs e)
	{
		barometer.Stop();
		barometer.ReadingChanged -= Barometer_ReadingChanged;
		Startbtn.IsEnabled = true;
		Stopbtn.IsEnabled = false;	
	}

    private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
    {
		double baro = e.Reading.PressureInHectopascals;
		baroLabel.Text = String.Format("{0,5:F2}hPa", baro); 
		myCanvas.AddData(baro);
		myCanvas.Invalidate();
    }
}

