using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CompassArrow
{
    internal class DataGraphicsView : GraphicsView
    {
        public GraphicsDrawable GraphicsDrawable = new GraphicsDrawable();

        public DataGraphicsView()
        {
            Drawable = GraphicsDrawable;
        }


        internal void setData(float heading)
        {
            this.GraphicsDrawable.dir = heading;
        }
    }
}
