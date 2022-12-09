namespace WindowBrightness02;

public partial class MainPage : ContentPage
{
  InterfaceBrightness m_interfaceBrightness;
  MauiService m_mauiService;
  public MainPage(InterfaceBrightness brightness)
  {
    InitializeComponent();
    LightLabel.Text = "화면 밝기 고정";
    m_interfaceBrightness = brightness;
    m_mauiService = new MauiService(LightLabel);
  }

  private void StopBtn_Clicked(object sender, EventArgs e)
  {
    m_interfaceBrightness.StopLightSensor();
    StartBtn.IsEnabled = true;
    StopBtn.IsEnabled = false;
  }

  private void StartBtn_Clicked(object sender, EventArgs e)
  {
    m_interfaceBrightness.TransferObject(m_mauiService);
    StartBtn.IsEnabled = false;
    StopBtn.IsEnabled = true;
    m_interfaceBrightness.StartLightSensor();
  }
}

