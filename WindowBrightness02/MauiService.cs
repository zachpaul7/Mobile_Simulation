using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBrightness02
{
  public class MauiService
  {
    Label m_lightLabel;
    public MauiService(Label label)
    {
      m_lightLabel = label;
    }
    public void SetLightLevel(int level)
    {
      m_lightLabel.Text = String.Format("화면 밝기 : {0, 3}", level);
    }
  }
}
