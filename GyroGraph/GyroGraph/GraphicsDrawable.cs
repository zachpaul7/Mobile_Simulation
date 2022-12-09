using Microsoft.Maui.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GyroGraph
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
            
            if (drawData.Count == 0)
            {
                return;
            }
            int cnt = drawData.Count;
            
            for (int i = 0; i < cnt; i++)
            {
                Vector3 data = (Vector3)drawData[i];

                canvas.FillColor = new Color(1.0f, 0, 0);
                canvas.FillRectangle(i, 30 * data.X, 5, 5);

                canvas.FillColor = new Color(0, 1.0f, 0);
                canvas.FillRectangle(i, 30 * data.Y, 5, 5);

                canvas.FillColor = new Color(0, 0, 1.0f);
                canvas.FillRectangle(i, 30 * data.Z, 5, 5);
            }
        }
    }
}
