using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFXIV_WYB;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MPTimer.GetTimer());
            Console.WriteLine("加载窗体");
            Console.ReadLine();
        }
    }
}
