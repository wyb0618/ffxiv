using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIV_ACT_Plugin;
using FFXIV_ACT_Plugin.Common;
using FFXIV_ACT_Plugin.Common.Models;


namespace FFXIV_WYB
{
    //public delegate void PlayerMPChangeDelegate();

    //public event PlayerMPChangeDelegate OnPlayerMPChange;

    class BLMListener
    {
        private BLMForm bLMForm;
        private Player player;
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin;
        public BLMListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin,BLMForm bLMForm)
        {
            this._ffxiv_Plugin = _ffxiv_Plugin;
            this.bLMForm = bLMForm;
            player = _ffxiv_Plugin.DataRepository.GetPlayer();

            _ffxiv_Plugin.DataSubscription.ParsedLogLine += new ParsedLogLineDelegate(ParsedLogLineDelegateHandler);
    
        }

        public void ParsedLogLineDelegateHandler(uint sequence,int messagetype,String message) {


            bLMForm.printOut("sequence:" + sequence.ToString() + "," + "messagetype:" + messagetype.ToString() + "," + "message:" + message);
            if (messagetype == 39) {
                bLMForm.printMsg("sequence:"+sequence.ToString()+","+ "messagetype:"+ messagetype.ToString()+","+ "message:"+ message);
                bLMForm.printMsg(Environment.NewLine);
            }

           
        }
   
    }
}
