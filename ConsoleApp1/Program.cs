using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLMHelper;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MPTicker mpt = MPTicker.GetMpTicker();
            mpt.ShowTicker();
            Console.ReadLine();
        }
    }
}
