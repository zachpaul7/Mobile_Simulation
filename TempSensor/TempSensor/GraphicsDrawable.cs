using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TempSensor
{
    public class GraphicsDrawable : IDrawable
    {
        public int level;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Translate(dirtyRect.Center.X, dirtyRect.Center.Y);

            PathF path = new PathF();
            path.AppendRectangle(-100,-100,200,200);

            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 10;
            canvas.DrawPath(path);

            if(level == 0)
            {
                canvas.FillColor = Color.FromRgb(0, 0, 0);
                canvas.FillPath(path);
            }
            else if(level < 70)
            {
                canvas.FillColor = Color.FromRgb(0, 0, 255);
                canvas.FillPath(path);
            }
            else if (level >= 70 & level <= 150)
            {
                canvas.FillColor = Color.FromRgb(255, 255, 0);
                canvas.FillPath(path);
            }
            else if (level > 150)
            {
                canvas.FillColor = Color.FromRgb(255, 0, 0);
                canvas.FillPath(path);
            }

        }
    }
}
