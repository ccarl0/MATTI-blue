using Android.Bluetooth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mattiBlue.Services
{
    public interface IBluetoothProfile
    {
        Task<List<BluetoothDevice>> ScanForDevicesAsync();
        Task<bool> ConnectToDeviceAsync(BluetoothDevice device);
        // Add other methods as needed for your Android Bluetooth communication
    }
}
