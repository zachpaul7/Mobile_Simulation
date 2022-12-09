using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightFind
{
    public interface InterfaceTransLabel
    {
        void TransLightLabel(Label label);
        void StartSensor();
        void StopSensor();
    }
}
