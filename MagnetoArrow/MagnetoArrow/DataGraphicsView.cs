using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MagnetoArrow
{
    internal class DataGraphicsView : GraphicsView
    {
        public GraphicsDrawable GraphicsDrawable = new GraphicsDrawable();

        public DataGraphicsView()
        {
            Drawable = GraphicsDrawable;
        }

        public void setData(Vector3 v)
        {
            this.GraphicsDrawable.dir = v;
        }
    }
}
