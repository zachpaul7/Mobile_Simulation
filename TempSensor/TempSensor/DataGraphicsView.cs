using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TempSensor
{
    public class DataGraphicsView : GraphicsView
    {
        public GraphicsDrawable GraphicsDrawable = new GraphicsDrawable();

        public DataGraphicsView()
        {
            Drawable = GraphicsDrawable;
        }
        public void getData(int v)
        {
            this.GraphicsDrawable.level = v;
        }
    }
}
