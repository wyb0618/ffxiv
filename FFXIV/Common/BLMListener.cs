using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIV_ACT_Plugin;
using FFXIV_ACT_Plugin.Common;


namespace FFXIV_WYB
{
    public delegate void PlayerStatsChanged();
    class BLMListener
    {
        private BLMForm bLMForm;
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin;
        public BLMListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin,BLMForm bLMForm)
        {
            this._ffxiv_Plugin = _ffxiv_Plugin;
            this.bLMForm = bLMForm;
            _ffxiv_Plugin.DataSubscription.PlayerStatsChanged += new PlayerStatsChangedDelegate(PlayerStatsChangedHandler);

        }

        public void PlayerStatsChangedHandler(object playerStats) {
            bLMForm.printMsg(playerStats.ToString());
        }
    }
}
