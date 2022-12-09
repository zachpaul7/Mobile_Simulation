using Android.OS;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Font = Microsoft.Maui.Graphics.Font;

namespace Graphics
{
    internal class GraphicsDrawable : IDrawable
    {
        Random rnd = new Random();
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float r = (float)rnd.NextDouble();
            float g = (float)rnd.NextDouble();
            float b = (float)rnd.NextDouble();
            canvas.StrokeColor = new Color(r, g, b);
            canvas.StrokeSize = 6;

            //ㅂ 
            canvas.DrawLine(5, 0, 5, 60);
            canvas.DrawLine(40, 0, 40, 60);
            canvas.DrawLine(5, 30, 40, 30);
            canvas.DrawLine(5, 60, 40, 60);
            //ㅏ
            canvas.DrawLine(55, 0, 55, 65);
            canvas.DrawLine(55, 30, 70, 30);
            //ㄱ
            canvas.DrawLine(5, 75, 55, 75);
            canvas.DrawLine(55, 75, 55, 100);
            //ㅅ
            canvas.DrawLine(140, 10, 100, 60);
            canvas.DrawLine(123, 25, 150, 60);
            //l
            canvas.DrawLine(170, 5, 170, 70);
            //ㄴ
            canvas.DrawLine(120, 75, 120, 95);
            canvas.DrawLine(120, 95, 170, 95);
            //ㅇ
            canvas.DrawCircle(235, 35, 20);
            //ㅕ
            canvas.DrawLine(283, 5, 283, 60);
            canvas.DrawLine(268, 20, 283, 20);
            canvas.DrawLine(268, 42, 283, 42);
            //ㅇ
            canvas.DrawCircle(260, 80, 18);

            String name = "박신영";
            canvas.FontSize = 48;
            canvas.Font = new Font("Arial");
            canvas.FontColor = Colors.Blue;
            canvas.DrawString(name, 150,150,HorizontalAlignment.Center);

            canvas.FillColor = new Color(1 - r, 1 - g, 1 - b);
        }
        public void AddData()
        {
            Console.WriteLine("AddData");
        }
    }
}
