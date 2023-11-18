using CommunityToolkit.Mvvm.ComponentModel;
using mattiBlue.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using BluetoothDevice = Android.Bluetooth.BluetoothDevice;

namespace mattiBlue.ViewModels
{
    partial class ContactsViewModel : ObservableObject
    {
        private IBluetoothProfile bluetoothProfile;

        [ObservableProperty]
        private List<BluetoothDevice> devices;

        public ContactsViewModel(mattiBlue.Services.IBluetoothProfile bluetoothProfile)
        {
            this.bluetoothProfile = bluetoothProfile;
        }

        [RelayCommand]
        private async Task ExecuteScanForDevicesCommand()
        {
            try
            {
                var scannedDevices = await bluetoothProfile.ScanForDevicesAsync();
                Devices.AddRange(scannedDevices);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error scanning for devices: {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task ExecuteConnectToDeviceCommand(BluetoothDevice device)
        {
            try
            {
                if (await bluetoothProfile.ConnectToDeviceAsync(device))
                {
                    // Handle successful connection
                    Console.WriteLine($"Connected to {device.Name}");
                }
                else
                {
                    // Handle connection failure
                    Console.WriteLine($"Failed to connect to {device.Name}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error connecting to device: {ex.Message}");
            }
        }
    }
}
