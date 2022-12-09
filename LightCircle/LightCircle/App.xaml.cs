namespace LightCircle;

public partial class App : Application
{
    public App(MainPage page)
    {
        InitializeComponent();

        //MainPage = new AppShell();
        MainPage = page;
    }
}
