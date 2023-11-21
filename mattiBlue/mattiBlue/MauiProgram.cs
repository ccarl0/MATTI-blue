using Android.Widget;
using mattiBlue.ViewModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
//using Microsoft.Maui.Essentials;

namespace mattiBlue
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            builder.Services.AddSingleton<IConnectivity>((e) => Connectivity.Current);
            //builder.Services.AddSingleton<IToast>((e) => new Toaster());

            builder.Services.AddSingleton<MainViewModel>();
            //builder.Services.AddTransient<DetailViewModel>();


            builder.Services.AddSingleton<MainPage>();
            //builder.Services.AddTransient<DetailPage>();

            return builder.Build();
        }
    }
}
