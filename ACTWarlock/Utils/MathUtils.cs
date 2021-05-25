using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACTWarlock.Utils
{
    class MathUtils
    {
        public static double calDistance(double x1,double x2,double y1,double y2)
        {
            return Math.Sqrt(Math.Abs(x1 - x2) * Math.Abs(x1 - x2) + Math.Abs(y1 - y2) * Math.Abs(y1 - y2));
        }
    }
}
