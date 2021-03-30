using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Models
{
    class Person
    {
        public double x;
        public double y;
        public string name;
        public Boolean ablity;
        public double face;

        public Person(string name)
        {
            this.name = name;
            x = 0;
            y = 0;
        }

        public Boolean Distance(double x1, double y1, double d)
        {
            if(Math.Sqrt(Math.Pow(x-x1,2)+ Math.Pow(y - y1, 2))<=d)
                return true;
            else
                return false;
        }

        internal bool FaceBetween(double f1, double f2)
        {
            if (face < f1 || face > f2) return false;
            return true;
        }
    }
}
