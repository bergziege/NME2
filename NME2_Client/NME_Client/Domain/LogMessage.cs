using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NME2.Properties;

namespace NME2.Domain
{
    public class LogMessage
    {
        public DateTime DateTime { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return string.Format(Resources.MainView_LOG_Date_Format, DateTime.Now) + " : " + Message;
        }
    }
}
