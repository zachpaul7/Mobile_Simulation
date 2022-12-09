using Microsoft.Maui.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GyroGraphAngle
{
    internal class GraphicsDrawable : IDrawable
    {
        public ArrayList drawData = new();
        public int maxData = 300;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Translate(0, dirtyRect.Center.Y);
            canvas.DrawLine(dirtyRect.Left,0,dirtyRect.Right,0);
            canvas.DrawLine(0, 150, 0,-150);
            int cnt = drawData.Count;

            for (int i = 0; i < cnt; i++)
            {
                Vector3 data = (Vector3)drawData[i];
                var red = new Color(1.0f, 0, 0);
                var green = new Color(0, 1.0f, 0);
                var blue =  new Color(0, 0, 1.0f);

                if (i==0){
                    canvas.StrokeColor = red;
                    canvas.DrawLine(0, 0, i, 40 * data.X);

                    canvas.StrokeColor=green;
                    canvas.DrawLine(0, 0, i, 40 * data.Y);

                    canvas.StrokeColor = blue;
                    canvas.DrawLine(0, 0, i, 40 * data.Z);
                }

                else if (i >= 1)
                {
                    Vector3 pdata = (Vector3)drawData[i - 1];

                    canvas.StrokeColor = red;
                    canvas.DrawLine(i - 1, 40 * pdata.X, i, 40 * data.X);

                    canvas.StrokeColor = green;
                    canvas.DrawLine(i - 1, 40 * pdata.Y, i, 40 * data.Y);

                    canvas.StrokeColor = blue;
                    canvas.DrawLine(i - 1, 40 * pdata.Z, i, 40 * data.Z);
                }

            }
        }
    }
}
