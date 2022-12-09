using System.Numerics;

namespace GyroGraph;

public partial class MainPage : ContentPage
{
	IGyroscope gyroscope = Gyroscope.Default;

	public MainPage()
	{
		InitializeComponent();
	}

	private void StartButton_Clicked(object sender, EventArgs e)
	{
		if(gyroscope.IsSupported)
		{
			if (!gyroscope.IsMonitoring)
			{
                gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                gyroscope.Start(SensorSpeed.UI);
            }
        }
	}
	
	private void StopButton_Clicked(object sender, EventArgs e)
	{
        if (gyroscope.IsSupported)
        {
            if (gyroscope.IsMonitoring)
            {
                gyroscope.Stop();
                gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
            }
        }
    }

    private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {
        Vector3 omega = e.Reading.AngularVelocity;
        myCanvas.AddData(omega);
        myCanvas.Invalidate();
    }
}

