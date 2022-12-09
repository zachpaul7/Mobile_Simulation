using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempSensor
{
    public interface InterfaceCelsius
    {
        void TransferObject(MauiService service);
        void StartTempSensor();
        void StopTempSensor();
    }
}
