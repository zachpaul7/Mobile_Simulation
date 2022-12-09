using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using LightCircle;

namespace LightCircle
{
    public class DataGraphicsView : GraphicsView
    {
        public GraphicsDrawable GraphicsDrawable = new GraphicsDrawable();

        public DataGraphicsView()
        {
            Drawable = GraphicsDrawable;
        }
        public void getData(float v)
        {
            this.GraphicsDrawable.evalue = v;
        }
    }
}
