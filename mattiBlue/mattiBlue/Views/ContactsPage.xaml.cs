using mattiBlue.ViewModels;
using mattiBlue.Services;

namespace mattiBlue.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
        IBluetoothProfile bluetoothProfile = new BluetoothProfile();
        BindingContext = new ContactsViewModel(bluetoothProfile);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var enable = new Android.Content.Intent(
                    Android.Bluetooth.BluetoothAdapter.ActionRequestEnable);
        enable.SetFlags(Android.Content.ActivityFlags.NewTask);

        var disable = new Android.Content.Intent(
                    Android.Bluetooth.BluetoothAdapter.ActionRequestDiscoverable);
        disable.SetFlags(Android.Content.ActivityFlags.NewTask);

        var bluetoothManager = (Android.Bluetooth.BluetoothManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.BluetoothService);
        var bluetoothAdapter = bluetoothManager.Adapter;
        if (bluetoothAdapter.IsEnabled == true)
        {
            Android.App.Application.Context.StartActivity(disable);
            //  disable the bluetooth;
        }
        else
        {
            // enable the bluetooth
            Android.App.Application.Context.StartActivity(enable);

        }
    }
}