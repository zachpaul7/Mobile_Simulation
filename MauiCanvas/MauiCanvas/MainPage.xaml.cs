using Microsoft.Maui.Devices.Sensors;
using System.Numerics;

namespace MauiCanvas;

public partial class MainPage : ContentPage
{
	IAccelerometer accelerometer = Accelerometer.Default;
	public MainPage()
	{
		InitializeComponent();
		myCanvas.ClearData();
	}

	private void Start_Button_Clicked(object sender, EventArgs e)
	{
		if(accelerometer.IsSupported)
		{
			if(!accelerometer.IsMonitoring)
			{
				accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
				accelerometer.Start(SensorSpeed.UI);
				StartButton.IsEnabled = false;
				StopButton.IsEnabled =	true;
            }
		}
	}

	private void Stop_Button_Clicked(object sender, EventArgs e)
	{
        if (accelerometer.IsSupported)
        {
            if (accelerometer.IsMonitoring)
            {
                accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                accelerometer.Stop();
                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
            }
        }
    }

	private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
	{
		Vector3 data = e.Reading.Acceleration;
		myCanvas.AddData(data);
		myCanvas.Invalidate();
	}
}

