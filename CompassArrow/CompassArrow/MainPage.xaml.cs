namespace CompassArrow;

public partial class MainPage : ContentPage
{
	ICompass compass = Compass.Default;

	public MainPage()
	{
		
		InitializeComponent();
	}

	private void StartBtn_Clicked(object sender, EventArgs e)
	{
		if (compass.IsSupported)
		{
			if (!compass.IsMonitoring)
			{
				compass.ReadingChanged += Compass_ReadingChanged;
				compass.Start(SensorSpeed.UI);
				StartBtn.IsEnabled = false;
				StopBtn.IsEnabled = true;
			}
		}
	}

    private void StopBtn_Clicked(object sender, EventArgs e)
    {
        if (compass.IsSupported)
        {
            if (compass.IsMonitoring)
            {
                compass.Stop();
                StartBtn.IsEnabled = true;
                StopBtn.IsEnabled = false;
                compass.ReadingChanged -= Compass_ReadingChanged;
            }
        }
    }

    private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
	{
		CompassData data = e.Reading;
		float heading = (float)data.HeadingMagneticNorth;
		xLabel.Text = data.ToString();
		myCanvas.setData(heading);
        myCanvas.Invalidate();
    }
}

