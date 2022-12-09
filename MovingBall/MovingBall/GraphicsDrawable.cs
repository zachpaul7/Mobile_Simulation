
using Microsoft.Maui.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MovingBall
{
    internal class GraphicsDrawable : IDrawable
    {

        public Vector3 dir;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Translate(dirtyRect.Center.X, dirtyRect.Center.Y);
            canvas.StrokeSize = 6;

            Vector2 vec = new Vector2(dir.X, dir.Y);

            canvas.StrokeColor = Colors.Red;
            float vecx = -vec.X * 400;
            float vecy = vec.Y * 400;
            canvas.DrawCircle(vecx, vecy, 20);
            
            canvas.StrokeColor = Colors.Blue;
            Vector2 vecc = Vector2.Normalize(vec) * 100;
            canvas.DrawLine(0, 0,-vecc.X, vecc.Y);

        }
    }
}
