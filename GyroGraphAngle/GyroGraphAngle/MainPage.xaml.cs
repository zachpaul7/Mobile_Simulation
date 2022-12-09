using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace GyroGraphAngle;

public partial class MainPage : ContentPage
{
    IGyroscope gyroscope = Gyroscope.Default;
    DateTime prevTime;
    DateTime currentTime;
    double AngleX;
    double AngleY;
    double AngleZ;
    double deltaTime;

    double maxangX = 0;
    double maxangY = 0;
    double maxangZ = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
        if (gyroscope.IsSupported)
        {
            if (!gyroscope.IsMonitoring)
            {
                gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                gyroscope.Start(SensorSpeed.UI);
                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
                prevTime = DateTime.Now;
                currentTime = DateTime.Now;
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
                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
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
        deltaTime = elapsedSpan.TotalSeconds;
        prevTime = currentTime;

        myCanvas.AddData(dir);

        calculate(dir);
        MaxAngular(dir);

        LabelAngle.Text = $"Rotation Angle = [{AngleX:N1}, {AngleY:N1}, {AngleZ:N1}]";
        LabelMax.Text = $"Max Angle = [{maxangX:N1}, {maxangY:N1}, {maxangZ:N1}]";

        myCanvas.Invalidate();
    }

    private void calculate(Vector3 dir)
    {
        dir.X = (float)(dir.X * 180 / Math.PI);
        AngleX += (deltaTime * dir.X);

        dir.Y = (float)(dir.Y * 180 / Math.PI);
        AngleY += (deltaTime * dir.Y);

        dir.Z = (float)(dir.Z * 180 / Math.PI);
        AngleZ += (deltaTime * dir.Z);
    }

    private void MaxAngular(Vector3 dir)
    {
        if(Math.Abs (dir.X) > maxangX)
        {
            maxangX = Math.Abs(dir.X);
        }
        else if (Math.Abs(dir.Y) > maxangY)
        {
            maxangY = Math.Abs(dir.Y);
        }
        else if (Math.Abs(dir.Z) > maxangZ)
        {
            maxangZ = Math.Abs(dir.Z);
        }
    }
}