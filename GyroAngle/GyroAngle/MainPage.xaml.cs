using System.Collections;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace GyroAngle;

public partial class MainPage : ContentPage
{
    IGyroscope gyroscope = Gyroscope.Default;
    DateTime prevTime;
    DateTime currentTime;
    double AngleX;
    double AngleY;
    double AngleZ;

    public MainPage()
    { 
        InitializeComponent();

    }
    private void StartBtn_Clicked(object sender, EventArgs e)
    {
        if (gyroscope.IsSupported)
        {
            if (!gyroscope.IsMonitoring)
            {
                gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                gyroscope.Start(SensorSpeed.UI);
                StartBtn.IsEnabled = false;
                StopBtn.IsEnabled = true;
                prevTime = DateTime.Now;
                currentTime = DateTime.Now;
            }
        }
    }

    private void StopBtn_Clicked(object sender, EventArgs e)
    {
        if (gyroscope.IsSupported)
        {
            if (gyroscope.IsMonitoring)
            {
                gyroscope.Stop();
                gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
                StartBtn.IsEnabled = true;
                StopBtn.IsEnabled = false;
            }
        }
    }
    private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {

        Vector3 dir = e.Reading.AngularVelocity;
        LabelGyroscope.Text = $"Angluar Velocity = [{dir.X * 180 / Math.PI:N1}, {dir.Y * 180 / Math.PI:N1}, {dir.Z * 180 / Math.PI:N1}]";

        currentTime = DateTime.Now;
        long elapsedTicks = currentTime.Ticks - prevTime.Ticks;
        TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
        double deltaTime = elapsedSpan.TotalSeconds;
        prevTime = currentTime;

        dir.X = (float)(dir.X * 180 / Math.PI);
        AngleX += (deltaTime * dir.X);

        dir.Y = (float)(dir.Y * 180 / Math.PI);
        AngleY += (deltaTime * dir.Y);

        dir.Z = (float)(dir.Z * 180 / Math.PI);
        AngleZ += (deltaTime * dir.Z);

        LabelAngle.Text = $"Angle = [{AngleX:N1}, {AngleY:N1}, {AngleZ:N1}]";
    }

}

