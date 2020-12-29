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
            Application.Run(mpt);
            Console.WriteLine("加载窗体");
            //获取文件信息并显示进度
            for (int i = 0; i <= 3000; i += 50)
            {
                //获取文件信息（实际过程忽略）
                System.Threading.Thread.Sleep(50);

                //更新进度条进度状态,当进度条为跑马灯模式时（ProgressBarStyle.Marquee）不可能调用该方法
                mpt.progressBar1.Value = i;
                if (i == 3000)
                {
                    i = 0;
                }
             }
        Console.ReadLine();
        }
    }
}
