using Microsoft.Maui.Devices.Sensors;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace LightFind;

public partial class MainPage : ContentPage
{
    IMagnetometer magnetometer = Magnetometer.Default;
    InterfaceTransLabel m_interfaceTransLabel;
    bool labelTransferred = false;
    public float v;
    public float pv = 0;


    public MainPage(InterfaceTransLabel interfaceTransLabel)
    {
        InitializeComponent();
        m_interfaceTransLabel = interfaceTransLabel;
    }

    private void StartBtn_Clicked(object sender, EventArgs e)
    {
        if (!labelTransferred)
        {
            m_interfaceTransLabel.TransLightLabel(lightLabel);
            labelTransferred = true;
        }
        StartBtn.IsEnabled = false;
        StopBtn.IsEnabled = true;

        m_interfaceTransLabel.StartSensor();
        magnetometer.Start(SensorSpeed.UI);
        lightLabel.MeasureInvalidated += LightLabel_MeasureInvalidated;
        magnetometer.ReadingChanged += Magnetometer_ReadingChanged;

    }

    private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
    {

        Vector3 data = e.Reading.MagneticField;

        if (pv < v)
        {
            maxmagLabel.Text = $"Max Angle : X:{data.X:N2}, Y:{data.Y:N2}, Z:{data.Z:N2}";
            pv = v;
            maxLabel.Text = $"Max Lumi : {pv:N2}";
        }

        magLabel.Text = $"Angle : X:{data.X:N2}, Y:{data.Y:N2}, Z:{data.Z:N2}";
    }

    private void LightLabel_MeasureInvalidated(object sender, EventArgs e)
    {
        Label label1 = (Label)sender;
        v = float.Parse(label1.Text);
    }

    private void StopBtn_Clicked(object sender, EventArgs e)
    {
        StartBtn.IsEnabled = true;
        StopBtn.IsEnabled = false;
        lightLabel.MeasureInvalidated -= LightLabel_MeasureInvalidated;
        magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
        m_interfaceTransLabel.StopSensor();
        magnetometer.Stop();
    }
}