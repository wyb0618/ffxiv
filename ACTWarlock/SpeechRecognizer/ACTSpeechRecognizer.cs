using ACTWarlock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

//创建Act语音识别器
namespace ACTWarlock.SpeechRecognizer
{
    public sealed class ACTSpeechRecognizer
    {
        private static readonly Lazy<ACTSpeechRecognizer> _ACTSpeechRecognizer = new Lazy<ACTSpeechRecognizer>(() => new ACTSpeechRecognizer());
        public SpeechRecognitionEngine recognizer { get; set; }

        //构造方法
        private ACTSpeechRecognizer()
        {
            recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("zh-CN"));

            //识别默认音频输入设音输入
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(new Grammar(@"act.xml"));
            Console.WriteLine("创建成功");
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognizer_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            PostUtils.sendCommand("Recognized text: " + e.Result.Semantics["act"].Value);
        }

        //获取语音识别器实例
        public static ACTSpeechRecognizer GetInstance
        {
            get
            {
                return _ACTSpeechRecognizer.Value;
            }
        }

        public void Disposed()
        {
            recognizer.RecognizeAsyncStop();
            recognizer.Dispose();
        }
    }
}
