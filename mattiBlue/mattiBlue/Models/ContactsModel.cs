using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mattiBlue.Models
{
    public class BluetoothDevice
    {
        public BluetoothDevice(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        // Add other properties as needed (e.g., SignalStrength, DeviceType, etc.)

        public override string ToString()
        {
            return $"{Name} ({Address})";
        }
    }
}
