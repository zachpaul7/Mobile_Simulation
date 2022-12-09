namespace LightCircle;

public partial class MainPage : ContentPage
{
    InterfaceTransLabel m_interfaceTransLabel;
    bool labelTransferred = false;
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
        lightLabel.MeasureInvalidated += LightLabel_MeasureInvalidated;
    }

    private void LightLabel_MeasureInvalidated(object sender, EventArgs e)
    {
        float v = float.Parse(lightLabel.Text);
        float brightness = 1 - (v / 1000);
        myCanvas.getData(brightness);
        myCanvas.Invalidate();
    }

    private void StopBtn_Clicked(object sender, EventArgs e)
    {
        StartBtn.IsEnabled = true;
        StopBtn.IsEnabled = false;
        lightLabel.MeasureInvalidated -= LightLabel_MeasureInvalidated;
        m_interfaceTransLabel.StopSensor();
        
    }
}

