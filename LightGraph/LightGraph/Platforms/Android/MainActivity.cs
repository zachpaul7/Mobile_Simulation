using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Hardware;
using Android.OS;

namespace LightGraph;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public static SensorManager m_sensorManager;
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        m_sensorManager = (SensorManager)GetSystemService(Context.SensorService);
    }
}
