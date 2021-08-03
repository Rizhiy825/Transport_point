using System;
using System.Collections.Generic;
using System.Text;

namespace Transport_point
{

    class Point
    {
        public double x
        {
            get;
            set;
        }
        public double y
        {
            get;
            set;
        }

        public Point(double xCoord, double yCoord)
        {
            x = xCoord;
            y = yCoord;
        }



    }
}
