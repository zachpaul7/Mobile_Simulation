using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Hardware;
using Android.OS;
using Android.Provider;

namespace WindowBrightness02;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
  public static SensorManager m_sensorManager;
  public static ContentResolver m_contentResolver;
  protected override void OnCreate(Bundle savedInstanceState)
  {
    base.OnCreate(savedInstanceState);
    askPermission(this);
    m_sensorManager = (SensorManager)GetSystemService(Context.SensorService);
    m_contentResolver = this.ContentResolver;
  }
  public void askPermission(Context c)
  {
    if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
    {
      if (!Settings.System.CanWrite(c))
      {
        Intent i = new Intent(Settings.ActionManageWriteSettings);
        c.StartActivity(i);
      }
    }
  }
}
