using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempSensor
{
    public class MauiService
    {
        Label m_tempLabel;
        DataGraphicsView m_myCanvas = new DataGraphicsView();

        public MauiService(Label label, DataGraphicsView myCanvas)
        {
            m_tempLabel = label;
            m_myCanvas = myCanvas;
        }

        public void SetTempLevel(int level)
        {
            m_tempLabel.Text = String.Format("밝기 : {0,3}", level);
            m_myCanvas.getData(level);
            m_myCanvas.Invalidate();
        }
    }
}
