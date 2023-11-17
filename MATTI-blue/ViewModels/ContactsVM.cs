using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InTheHand.Net.Sockets;
using System.Collections.Generic;
using System.Linq;

namespace MATTI_blue.ViewModels
{
    public partial class ContactsVM : ObservableObject
    {
        [ObservableProperty]
        List<BluetoothDeviceInfo> devices;

        //public ContactsVM()
        //{
        //    GetActiveDevices();
        //}

        [RelayCommand]
        public async Task GetActiveDevices()
        {
            await Application.Current.MainPage.DisplayAlert("Success", "Device discovery completed successfully.", "OK");
            try
            {
                BluetoothClient bluetoothClient = new BluetoothClient();
                Devices = bluetoothClient.DiscoverDevices().ToList();

                // Show a success message using DisplayAlert
                await Application.Current.MainPage.DisplayAlert("Success", "Device discovery completed successfully.", "OK");
            }
            catch (Exception ex)
            {
                // Show an error message using DisplayAlert
                await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }
    }
}
