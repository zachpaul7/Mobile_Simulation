
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompassArrow
{
    internal class GraphicsDrawable : IDrawable
    {

        public float dir;
        

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            
            canvas.Translate(dirtyRect.Center.X, dirtyRect.Center.Y);
            canvas.StrokeSize = 6;
            canvas.StrokeColor = Colors.Red;

            float rad = (float)(dir * Math.PI / 180);
            
            float x = (float)(100 * Math.Sin(rad));
            float y = (float)(100 * Math.Cos(rad));
            
            canvas.DrawLine(0, 0, -x, -y);
        }
    }
}
