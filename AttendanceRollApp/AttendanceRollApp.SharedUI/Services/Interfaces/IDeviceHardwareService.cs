using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRollApp.SharedUI.Services.Interfaces
{
    public interface IDeviceHardwareService
    {
        bool IsSupported { get; }
    }
}
