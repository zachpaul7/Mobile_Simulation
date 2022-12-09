using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LightCircle
{
    public class GraphicsDrawable : IDrawable
    {
        public float evalue;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Translate(dirtyRect.Center.X, dirtyRect.Center.Y);
            canvas.StrokeSize = 6;
            
            PathF path = new PathF();
            path.AppendCircle(0, 0, 100);

            canvas.StrokeColor = Colors.Blue;
            canvas.StrokeSize = 10;

            canvas.FillColor = Color.FromRgba(0, 0, 0, evalue);

            canvas.FillPath(path);
            canvas.DrawPath(path);
        }
    }
}
