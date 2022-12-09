using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LightGraph
{
    public class GraphicsDrawable : IDrawable
    {
        public int maxData = 300;
        public ArrayList drawData = new();
        
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Translate(0, dirtyRect.Center.Y);
            canvas.DrawLine(dirtyRect.Left, 0, dirtyRect.Right, 0);
            canvas.DrawLine(0, 150, 0, -150);
            int cnt = drawData.Count;

            var red = new Color(1.0f, 0, 0);

            for (int i = 0; i < cnt; i++)
            {
                float data = (float)drawData[i];

                if (i > 0)
                {
                    float pdata = (float)drawData[i - 1];

                    canvas.StrokeColor = red;
                    canvas.DrawLine(i - 1, -pdata, i, -data);
                }
                else
                {
                    canvas.StrokeColor = red;
                    canvas.DrawLine(0, 0, i, -data);
                }

            }
        }
    }
}
