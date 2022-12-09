
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MagnetoArrow
{
    internal class GraphicsDrawable : IDrawable
    {

        public Vector3 dir;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Translate(dirtyRect.Center.X, dirtyRect.Center.Y);
            canvas.StrokeSize = 6;
            canvas.StrokeColor = Colors.Red;
            //canvas.DrawLine(0, 0, dir.X, dir.Y);

            Vector2 vec = new Vector2(dir.X, dir.Y);
            vec = Vector2.Normalize(vec) * 100;
            canvas.DrawLine(0,0,vec.X,vec.Y);
        }
    }
}
