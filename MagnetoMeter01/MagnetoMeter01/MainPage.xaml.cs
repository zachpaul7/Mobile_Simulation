using System.Numerics;

namespace MagnetoMeter01;

public partial class MainPage : ContentPage
{
	IMagnetometer magnetometer = Magnetometer.Default;
	public MainPage()
	{
		InitializeComponent();
	}

	private void StopMeasure_Clicked(object sender, EventArgs e)
	{
        if (magnetometer != null && magnetometer.IsSupported)
        {
            if (magnetometer.IsMonitoring)
            {
				magnetometer.Stop();
                magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
                StartMeasure.IsEnabled = true;
                StopMeasure.IsEnabled = false;
            }
        }
    }

    private void StartMeasure_Clicked(object sender, EventArgs e)
	{
		if(magnetometer != null && magnetometer.IsSupported)
		{
			if(!magnetometer.IsMonitoring)
			{
				magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
				magnetometer.Start(SensorSpeed.UI);
				StartMeasure.IsEnabled = false;
				StopMeasure.IsEnabled = true;
			}
		}
	}

	private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
	{
		Vector3 value = e.Reading.MagneticField;
		valueMagnetic.Text = String.Format("{0:N2}:({1:N2}, {2:N2}, {3:N2})[uT]",
			value.Length(), value.X, value.Y, value.Z);
	}
}

