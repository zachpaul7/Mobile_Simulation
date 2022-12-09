namespace LightGraph;

public partial class MainPage : ContentPage
{
    InterfaceTransLabel m_interfaceTransLabel;
    bool labelTransferred = false;
    float v;
    private static System.Timers.Timer timer;

    public MainPage(InterfaceTransLabel interfaceTransLabel)
    {
        EventTimer();
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
        lightLabel.MeasureInvalidated += LightLabel_MeasureInvalidated;
    }

    private void LightLabel_MeasureInvalidated(object sender, EventArgs e)
    {
        v = float.Parse(lightLabel.Text);
 //       myCanvas.AddData(v);
 //       myCanvas.Invalidate();
    }

    private void StopBtn_Clicked(object sender, EventArgs e)
    {
        StartBtn.IsEnabled = true;
        StopBtn.IsEnabled = false;
        lightLabel.MeasureInvalidated -= LightLabel_MeasureInvalidated;
        m_interfaceTransLabel.StopSensor();
        timer.Stop();
        timer.Dispose();
    }

    private void EventTimer()
    {
        timer = new System.Timers.Timer(200);
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        myCanvas.AddData(v);
        myCanvas.Invalidate();
    }
}