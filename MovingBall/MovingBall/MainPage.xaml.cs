using System.Numerics;

namespace MovingBall;

public partial class MainPage : ContentPage
{
	IAccelerometer accelerometer = Accelerometer.Default;

	public MainPage()
	{
		InitializeComponent();
	}

	
	private void StartButton_Clicked(object sender, EventArgs e)
	{
		if(accelerometer.IsSupported)
		{
			if (!accelerometer.IsMonitoring)
			{
				accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
				accelerometer.Start(SensorSpeed.UI);
                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
            }
		}
	}

	private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
	{
		Vector3 data = e.Reading.Acceleration;
        myCanvas.setData(data);
        myCanvas.Invalidate();
    }



	private void StopButton_Clicked(object sender, EventArgs e)
	{
        if (accelerometer.IsSupported)
        {
            if (accelerometer.IsMonitoring)
            {
                accelerometer.Stop();
                accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
            }
        }
    }
}

