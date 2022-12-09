//using Android.Graphics;
using System.Collections;
using System.Numerics;
using ArrayList = System.Collections.ArrayList;

namespace MauiApp2;

public partial class MainPage : ContentPage
{
	IAccelerometer accelerometer = Accelerometer.Default;
	ArrayList data = new ArrayList();
    int num_data = 0;
    Vector3 result;
    Vector3 Avg;
    
    public MainPage()
	{
		InitializeComponent();
    }

	private void StartAcc_Clicked(object sender, EventArgs e)
	{
		if(accelerometer.IsSupported)
		{
			if(!accelerometer.IsMonitoring)
			{
				accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                accelerometer.Start(SensorSpeed.UI);
                num_data = int.Parse(numData.Text);
            }
		}
	}

	private void StopAcc_Clicked(object sender, EventArgs e)
	{
        if (accelerometer.IsSupported)
        {
			if (accelerometer.IsMonitoring)
			{
				accelerometer.Stop();
				accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            }
        }
    }
   
	private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
	{
		AccLabel.TextColor = Colors.Green;
        AvgLabel.TextColor = Colors.Green;
        numData.BackgroundColor = Colors.Green;
        MagLabel.TextColor = Colors.Green;
        Vector3 acc = e.Reading.Acceleration;
        float mag = e.Reading.Acceleration.Length();
        data.Add(acc);

        AccLabel.Text = $"Acc: X:{acc.X:N2}, Y:{acc.Y:N2}, Z:{acc.Z:N2}";
        MagLabel.Text = $"Mag: {mag:N2}";

        if (data.Count >= num_data)
        {
            Avg_Calculate();
            AvgLabel.Text = $"Avg: {Avg:N2}";
            data.Clear();
        }
    }

    private void Avg_Calculate()
	{
        result = new Vector3(0,0,0);

		for(int i = 0; i < num_data; i++)
		{
            result = result + (Vector3)data[i];
        }

        Avg = result / num_data;
    }

}

