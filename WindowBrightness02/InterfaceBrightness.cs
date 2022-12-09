using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBrightness02
{
  public interface InterfaceBrightness
  {
    void TransferObject(MauiService service);
    void StartLightSensor();
    void StopLightSensor();
  }
}
