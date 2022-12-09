using Microsoft.Maui.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BaroSensor
{
    internal class GraphicsDrawable : IDrawable
    {
        public ArrayList drawData = new();
        public int maxData = 300;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Translate(0, dirtyRect.Center.Y);
            canvas.DrawLine(dirtyRect.Left, 0, dirtyRect.Right, 0);
            canvas.DrawLine(0, 150, 0, -150);
            int cnt = drawData.Count;

            for (int i = 0; i < cnt; i++)
            {
                double data = (double)drawData[i];
                var red = new Color(1.0f, 0, 0);

                if (i == 0)
                {
                    canvas.StrokeColor = red;
                    canvas.DrawLine(0, 0, i, -(float)((data - 1000) * 20));
                }

                else if (i >= 1)
                {
                    double pdata = (double)drawData[i - 1];

                    canvas.StrokeColor = red;
                    canvas.DrawLine(i - 1, -(float)((pdata - 1000) * 20), i, -(float)((data - 1000) * 20));
                }

            }
        }
    }
}
