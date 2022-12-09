namespace TempSensor;

public partial class MainPage : ContentPage
{
    InterfaceCelsius m_interfaceCelsius;
    MauiService m_mauiService;
    

    public MainPage(InterfaceCelsius celsius)
    {
        InitializeComponent();
        TempLabel.Text = "밝기";
        m_interfaceCelsius = celsius;
        m_mauiService = new MauiService(TempLabel,myCanvas);
    }
    private void StartBtn_Clicked(object sender, EventArgs e)
    {
        m_interfaceCelsius.TransferObject(m_mauiService);
        StartBtn.IsEnabled = false;
        StopBtn.IsEnabled = true;
        m_interfaceCelsius.StartTempSensor();
    }
    private void StopBtn_Clicked(object sender, EventArgs e)
    {
        m_interfaceCelsius.StopTempSensor();
        StartBtn.IsEnabled = true;
        StopBtn.IsEnabled = false;
    }
}