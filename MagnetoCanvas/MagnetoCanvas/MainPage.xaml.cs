using System.Numerics;

namespace MagnetoCanvas;

public partial class MainPage : ContentPage
{
    IMagnetometer magnetometer = Magnetometer.Default;

    public MainPage()
    {
        InitializeComponent();
        myCanvas.ClearData();
    }

    private void Start_Button_Clicked(object sender, EventArgs e)
    {
        if (magnetometer != null && magnetometer.IsSupported)
        {
            if (!magnetometer.IsMonitoring)
            {
                magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
                magnetometer.Start(SensorSpeed.UI);
                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
            }
        }
    }

    private void Stop_Button_Clicked(object sender, EventArgs e)
    {
        if (magnetometer != null && magnetometer.IsSupported)
        {
            if (magnetometer.IsMonitoring)
            {
                magnetometer.Stop();
                magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
            }
        }
    }

    private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
    {
        Vector3 data = e.Reading.MagneticField;
        myCanvas.AddData(data);
        myCanvas.Invalidate();
    }
}

