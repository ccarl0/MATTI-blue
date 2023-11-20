using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Essentials;

namespace mattiBlue
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            EnsurePermissions();

            return builder.Build();
        }

        private static void EnsurePermissions()
        {
            var neededPermissions = new[]
            {
                Permissions.Bluetooth,
                Permissions.BluetoothConnect,
                Permissions.BluetoothScan
            };

            foreach (var permission in neededPermissions)
            {
                if (!MauiContext.Current.CheckSelfPermission(permission))
                {
                    MauiContext.Current.RequestPermissions(new[] { permission });
                }
            }
        }
    }
}
