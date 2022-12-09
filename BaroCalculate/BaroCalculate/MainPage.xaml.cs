
using System.Runtime.Intrinsics.X86;
using System.Numerics;
using ArrayList = System.Collections.ArrayList;

namespace BaroCalculate;

public partial class MainPage : ContentPage
{
	IBarometer barometer = Barometer.Default;
	public double firstdata;
	public double seconddata;
	public double result;
	public double baro;
	public double meter;
    public double m;

    const double P0 = 1013.25;
    const double rho = 1.225;
    const double g = 9.80665;
    const double L = 0.00976;
    const double T0 = 288.16;
    const double M = 0.02896968;
    const double R0 = 8.314462618;

    ArrayList array_meter = new ArrayList();
    int num_data = 0;
    double r;
    double Avg;

    public MainPage()
	{
		InitializeComponent();
	}

	private void FDatabtn_Clicked(object sender, EventArgs e)
	{
        firstdata = Avg;
        FDatabtn.IsEnabled = false;
        SDatabtn.IsEnabled = true;
    }

	private void SDatabtn_Clicked(object sender, EventArgs e)
	{
        seconddata = Avg;
		if (firstdata != 0)
		{
			if (firstdata > seconddata)
			{
                result = firstdata - seconddata;
            }
			else if(firstdata < seconddata)
			{
                result = seconddata - firstdata;
            }
            
            resultLabel.Text = String.Format("고도차 : {0,5:F2} m", result);
        }
		else
		{
			resultLabel.Text = ("first 데이터가 없습니다. ");
		}
        FDatabtn.IsEnabled = true;
        SDatabtn.IsEnabled = false;
    }

	private void Startbtn_Clicked(object sender, EventArgs e)
	{
        if (barometer.IsSupported)
        {
            if (!barometer.IsMonitoring)
            {
                barometer.ReadingChanged += Barometer_ReadingChanged;
                barometer.Start(SensorSpeed.UI);
                Startbtn.IsEnabled = false;
                Stopbtn.IsEnabled = true;
                num_data = int.Parse(numData.Text);
            }
        }
    }

	private void Stopbtn_Clicked(object sender, EventArgs e)
	{
        if (barometer.IsSupported)
        {
            if (barometer.IsMonitoring)
            {
                barometer.Stop();
                barometer.ReadingChanged -= Barometer_ReadingChanged;
                Startbtn.IsEnabled = true;
                Stopbtn.IsEnabled = false;
            }
        }
                
    }

    private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
    {
		baro = e.Reading.PressureInHectopascals;
        baroLabel.Text = String.Format("{0:F3}hPa", baro);

		CalculateHeight(baro);
        AltitudeHeight(baro);

        array_meter.Add(meter);

        heightLabel.Text = String.Format("{0:F3} m", meter);
        altitudeLabel.Text = String.Format("{0:F3} m", m );

        if (array_meter.Count >= num_data)
        {
            AverageHeight();
            AvgLabel.Text = $"Avg: {Avg:N2} m";
            array_meter.Clear();
        }
    }

	private void AltitudeHeight(double b)
	{
        m = (P0 - b) / (rho * g);
    }
	private void CalculateHeight(double b)
	{
        meter = T0 / L * (1 - Math.Pow(b / P0, R0 * L / (g * M)));
    }

    private void AverageHeight()
    {
        r = 0;

        for (int i = 0; i < num_data; i++)
        {
            r = r + (double)array_meter[i];
        }

        Avg = r / num_data;
    }
}

