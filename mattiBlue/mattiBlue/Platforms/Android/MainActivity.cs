using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using Microsoft.Maui.Essentials;


namespace mattiBlue
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]

    


    public class MainActivity : MauiAppCompatActivity
    {
        const int BluetoothConnectRequestCode = 101;
        const int BluetoothRequestCode = 102;
        const int BluetoothScanRequestCode = 103;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var currentContext = Application.Current.MainPage?.MainActivity;

            if (Build.VERSION.SdkInt > Android.OS.BuildVersionCodes.R && ActivityCompat.CheckSelfPermission(currentContext, Manifest.Permission.BluetoothConnect) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(currentContext, new string[] { Manifest.Permission.BluetoothConnect }, BluetoothConnectRequestCode);
            }

            if (Build.VERSION.SdkInt <= Android.OS.BuildVersionCodes.R && ActivityCompat.CheckSelfPermission(currentContext, Manifest.Permission.Bluetooth) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(currentContext, new string[] { Manifest.Permission.Bluetooth }, BluetoothRequestCode);
            }

            if (Build.VERSION.SdkInt <= Android.OS.BuildVersionCodes.R && ActivityCompat.CheckSelfPermission(currentContext, Manifest.Permission.BluetoothScan) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(currentContext, new string[] { Manifest.Permission.BluetoothScan }, BluetoothScanRequestCode);
            }
        }



    }
}