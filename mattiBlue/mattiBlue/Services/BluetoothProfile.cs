using Android.Bluetooth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mattiBlue.Services
{
    public class BluetoothProfile : IBluetoothProfile
    {
        public Task<bool> ConnectToDeviceAsync(BluetoothDevice device)
        {
            throw new NotImplementedException();
        }

        // Other methods

        public async Task<List<BluetoothDevice>> ScanForDevicesAsync()
        {
            var bluetoothAdapter = BluetoothAdapter.DefaultAdapter;

            if (bluetoothAdapter == null || !bluetoothAdapter.IsEnabled)
            {
                // Bluetooth is not supported or not enabled
                return new List<BluetoothDevice>();
            }

            var discoveredDevices = new List<BluetoothDevice>();

            // Start discovery
            bluetoothAdapter.StartDiscovery();

            // Wait for discovery to complete (you might want to add a timeout mechanism)
            await Task.Delay(5000); // Adjust the delay as needed

            // Get the list of discovered devices
            var bondedDevices = bluetoothAdapter.BondedDevices;
            foreach (var device in bondedDevices)
            {
                discoveredDevices.Add(device);
            }

            // Stop discovery (important to conserve resources)
            bluetoothAdapter.CancelDiscovery();

            return discoveredDevices;
        }
    }

}
