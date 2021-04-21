using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV.Models
{
    class Person
    {
        public double x { get; set; }
        public double y { get; set; }
        public string name { get; set; }
        public Boolean ablity { get; set; }
        public double face { get; set; }
        public string zone { get; set; }

        public Person()
        {

        }

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
