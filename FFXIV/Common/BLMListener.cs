using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIV_ACT_Plugin;
using FFXIV_ACT_Plugin.Common;
using FFXIV_ACT_Plugin.Common.Models;


namespace BLMHelper
{
    //public delegate void PlayerMPChangeDelegate();

    //public event PlayerMPChangeDelegate OnPlayerMPChange;

    class BLMListener
    {
        private BLMForm bLMForm;
        private MPTicker mpTicker;
        private Player player;
        private bool CombatantStatus;
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin;

        public BLMListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin, BLMForm bLMForm)
        {
            _ffxiv_Plugin = _ffxiv_Plugin;
            bLMForm = bLMForm;
            player = _ffxiv_Plugin.DataRepository.GetPlayer();
            mpTicker = MPTicker.GetMpTicker();

            if (player.JobID == 3)
                AddDelegate();

            _ffxiv_Plugin.DataSubscription.PlayerStatsChanged += new PlayerStatsChangedDelegate(PlayerStatsChangedHandler);

        }

        public void AddDelegate()
        {
            _ffxiv_Plugin.DataSubscription.ParsedLogLine += new ParsedLogLineDelegate(ParsedLogLineDelegateHandler);
            _ffxiv_Plugin.DataSubscription.CombatantAdded += new CombatantAddedDelegate(CombatantAddedDelegateHandler);
            _ffxiv_Plugin.DataSubscription.CombatantRemoved += new CombatantRemovedDelegate(CombatantRemovedDelegateHandler);
        }

        public void RemoveDelegate()
        {
            _ffxiv_Plugin.DataSubscription.ParsedLogLine -= ParsedLogLineDelegateHandler;
            _ffxiv_Plugin.DataSubscription.CombatantAdded -= CombatantAddedDelegateHandler;
            _ffxiv_Plugin.DataSubscription.CombatantRemoved -= CombatantRemovedDelegateHandler;
        }

        public void Close()
        {
            _ffxiv_Plugin.DataSubscription.PlayerStatsChanged -= PlayerStatsChangedHandler;
            RemoveDelegate();
        }

        public void PlayerStatsChangedHandler(object status)
        {
            if (player.JobID == 3)
                AddDelegate();
            Console.WriteLine(status.ToString());
        }

        public void ParsedLogLineDelegateHandler(uint sequence, int messagetype, String message)
        {
            if (messagetype == 39)
            {
                lock (this)
                {
                    if (mpTicker.Visible)
                        mpTicker.SyncAndStart();
                }
            }
            if(messagetype == "casting")
            {
                lock (this)
                {
                    if (!mpTicker.Visible)
                        mpTicker.ShowTicker();
                }
            }
        }

        public void CombatantAddedDelegateHandler(object combatant)
        {
            lock (this)
            {
                CombatantStatus = true;
                if (!mpTicker.Visible)
                    mpTicker.ShowTicker();
            }
        }

        public void CombatantRemovedDelegateHandler(object combatant)
        {
            lock (this)
            {
                CombatantStatus = false;

                if (mpTicker.Visible)
                    mpTicker.HideTicker();

                if (mpTicker.TickerEnable())
                    mpTicker.Stop();
            }
        }
    }
}
