﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Globalization;
using Triggernometry.Variables;

namespace Triggernometry
{

    public class Folder
    {

		private Regex rexz;
		private string _ZoneFilterRegularExpression;

        internal bool _FFXIVJobFilterEnabled { get; set; } = false;
        [XmlAttribute]
        public string FFXIVJobFilterEnabled
        {
            get
            {
                if (_FFXIVJobFilterEnabled == false)
                {
                    return null;
                }
                return _FFXIVJobFilterEnabled.ToString();
            }
            set
            {
                _FFXIVJobFilterEnabled = Boolean.Parse(value);
            }
        }

        internal Int64 _FFXIVJobFilter { get; set; } = 0;
        [XmlAttribute]
        public string FFXIVJobFilter
        {
            get
            {
                if (_FFXIVJobFilter == 0)
                {
                    return null;
                }
                return _FFXIVJobFilter.ToString(CultureInfo.InvariantCulture);
            }
            set
            {
                _FFXIVJobFilter = Int64.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        internal bool _EventFilterEnabled { get; set; } = false;
        [XmlAttribute]
        public string EventFilterEnabled
        {
            get
            {
                if (_EventFilterEnabled == false)
                {
                    return null;
                }
                return _EventFilterEnabled.ToString();
            }
            set
            {
                _EventFilterEnabled = Boolean.Parse(value);
            }
        }

        internal bool _ZoneFilterEnabled { get; set; } = false;
        [XmlAttribute]
        public string ZoneFilterEnabled
        {
            get
            {
                if (_ZoneFilterEnabled == false)
                {
                    return null;
                }
                return _ZoneFilterEnabled.ToString();
            }
            set
            {
                _ZoneFilterEnabled = Boolean.Parse(value);
            }
        }

        [XmlAttribute]
        public Guid Id { get; set; }

        [XmlAttribute]
        public string ZoneFilterRegularExpression
		{
			get
			{
				if (_ZoneFilterRegularExpression == "")
                {
                    return null;
                }
                return _ZoneFilterRegularExpression;
            }
			set
			{
				if (_ZoneFilterRegularExpression != value)
				{
					_ZoneFilterRegularExpression = value;
					try
					{
						rexz = new Regex(_ZoneFilterRegularExpression);
					}
					catch (Exception)
					{
						rexz = null;
					}
				}
			}
		}

        internal string FullPath
        {
            get
            {
                string name = Name;
                Folder f = Parent;
                while (f != null)
                {
                    if (f.Parent != null)
                    {
                        name = f.Name + @"\" + name;
                    }
                    f = f.Parent;
                }
                return name;
            }
        }

        private Regex rexe;
		private string _EventFilterRegularExpression;

		[XmlAttribute]
        public string EventFilterRegularExpression
		{
			get
			{
				if (_EventFilterRegularExpression == "")
                {
                    return null;
                }
                return _EventFilterRegularExpression;
            }
			set
			{
				if (_EventFilterRegularExpression != value)
				{
					_EventFilterRegularExpression = value;
					try
					{
						rexe = new Regex(_EventFilterRegularExpression);
					}
					catch (Exception)
					{
						rexe = null;
					}
				}
			}
		}		

		internal Folder Parent { get; set; }
        public List<Folder> Folders { get; set; }
        public List<Trigger> Triggers { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public bool Enabled { get; set; }

        internal Repository Repo { get; set; } = null;

        public Folder()
        {
            Folders = new List<Folder>();
            Triggers = new List<Trigger>();
            Enabled = true;
            Id = Guid.NewGuid();
        }

        public enum FilterFailReason
        {
            Passed,
            Failed,
            NotEnabled,
            Exception
        }

        public bool ParentsEnabled()
        {
            Folder f = this;
            while (f != null)
            {
                if (f.Enabled == false)
                {
                    return false;
                }
                f = f.Parent;
            }
            return true;
        }

        public bool IsLimited()
        {
            return (
                (_ZoneFilterEnabled == true)
                ||
                (_EventFilterEnabled == true)
                ||
                (_FFXIVJobFilterEnabled == true)
            );
        }

        public bool PassesZoneRestriction(string zone)
        {
            bool ret = true;
            Folder f = this;
            while (f != null && ret == true)
            {
                if (f._ZoneFilterEnabled == true)
                {
                    ret = f.rexz != null ? f.rexz.IsMatch(zone) : false;
                }
                f = f.Parent;
            }
            return ret;
        }
		
		public FilterFailReason PassesFilter(string zone, string evtext)
		{
			bool ret = true;
			Folder f = this;
			while (f != null && ret == true)
			{
                if (f.Enabled == false)
                {
                    return FilterFailReason.NotEnabled;
                }
                if (ret == true && f._ZoneFilterEnabled == true)
				{
					ret = f.rexz != null ? f.rexz.IsMatch(zone) : false;
				}		
				if (ret == true && f._EventFilterEnabled == true)
				{
					ret = f.rexe != null ? f.rexe.IsMatch(evtext) : false;
				}
                if (ret == true && f._FFXIVJobFilterEnabled == true)
                {
                    VariableDictionary vc = PluginBridges.BridgeFFXIV.GetMyself();
                    if (vc != null)
                    {
                        Int64 currentJob = 0;
                        Int64.TryParse(vc.GetValue("jobid").ToString(), out currentJob);
                        Int64 shifted = ((Int64)1) << ((int)currentJob - 1);
                        ret = ((f._FFXIVJobFilter & shifted) != 0);
                    }
                    else
                    {
                        ret = false;
                    }
                }
                f = f.Parent;
			}
			return ret == true ? FilterFailReason.Passed : FilterFailReason.Failed;
		}

    }

}
