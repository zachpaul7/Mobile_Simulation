using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MauiCanvas
{
    internal class GraphicsDrawable : IDrawable
    {
        public ArrayList drawData = new();
        public int maxData = 500;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if(drawData.Count == 0)
            {
                return;
            }
            int cnt = drawData.Count;

            canvas.FillColor = new Color(1.0f, 0, 0);
            for(int i = 0; i < cnt; i++)
            {
                Vector3 data = (Vector3)drawData[i];
                canvas.FillRectangle(i, 100 * (1 - data.X), 5, 5);
            }

            canvas.FillColor = new Color(0, 1.0f, 0);
            for (int i = 0; i < cnt; i++)
            {
                Vector3 data = (Vector3)drawData[i];
                canvas.FillRectangle(i, 100 * (1 - data.Y), 5, 5);
            }


            canvas.FillColor = new Color(0, 0, 1.0f);
            for (int i = 0; i < cnt; i++)
            {
                Vector3 data = (Vector3)drawData[i];
                canvas.FillRectangle(i, 100 * (1 - data.Z), 5, 5);
            }
        }
    }
}
