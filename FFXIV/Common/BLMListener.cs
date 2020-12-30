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
        private Player player;
        private bool CombatantStatus;
        private FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin;

        public BLMListener(FFXIV_ACT_Plugin.FFXIV_ACT_Plugin _ffxiv_Plugin, BLMForm bLMForm)
        {
            this._ffxiv_Plugin = _ffxiv_Plugin;
            this.bLMForm = bLMForm;
            player = _ffxiv_Plugin.DataRepository.GetPlayer();

            if (player.JobID == 25)
                AddDelegate();

            _ffxiv_Plugin.DataSubscription.PlayerStatsChanged += new PlayerStatsChangedDelegate(PlayerStatsChangedHandler);

        }

        public void AddDelegate()
        {
            _ffxiv_Plugin.DataSubscription.ParsedLogLine += new ParsedLogLineDelegate(ParsedLogLineDelegateHandler);
            //_ffxiv_Plugin.DataSubscription.CombatantAdded += new CombatantAddedDelegate(CombatantAddedDelegateHandler);
            //_ffxiv_Plugin.DataSubscription.CombatantRemoved += new CombatantRemovedDelegate(CombatantRemovedDelegateHandler);
        }

        public void RemoveDelegate()
        {
            _ffxiv_Plugin.DataSubscription.ParsedLogLine -= ParsedLogLineDelegateHandler;
            //_ffxiv_Plugin.DataSubscription.CombatantAdded -= CombatantAddedDelegateHandler;
            //_ffxiv_Plugin.DataSubscription.CombatantRemoved -= CombatantRemovedDelegateHandler;
        }

        public void Close()
        {
            _ffxiv_Plugin.DataSubscription.PlayerStatsChanged -= PlayerStatsChangedHandler;
            RemoveDelegate();
        }

        public void PlayerStatsChangedHandler(object status)
        {
            if (player.JobID == 25)
                AddDelegate();
            else
                RemoveDelegate();
        }

        public void ParsedLogLineDelegateHandler(uint sequence, int messagetype, String message)
        {
            
            if (messagetype == 39)
            {
               
            }
            //if(messagetype == "casting")
            //{
            //    lock (this)
            //    {
            //        if (!mpTicker.Visible)
            //            mpTicker.ShowTicker();
            //    }
            //}
        }

        public void CombatantAddedDelegateHandler(object combatant)
        {
            CombatantStatus = true;
            if (!MPTicker.GetMpTicker().Visible)
                MPTicker.GetMpTicker().ShowTicker();
        }

        public void CombatantRemovedDelegateHandler(object combatant)
        {
            CombatantStatus = false;
            if (MPTicker.GetMpTicker().Visible)
                MPTicker.GetMpTicker().HideTicker();
            if (MPTicker.GetMpTicker().TickerEnable())
                MPTicker.GetMpTicker().Stop();
        }
    }
}
