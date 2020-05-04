using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWSv3
{
    public static class TimeAgo
    {
        public static string GetTimeSince(DateTime objDateTime)
        {
            // here we are going to subtract the passed in DateTime from the current time converted to UTC
            TimeSpan ts = DateTime.Now.Subtract(objDateTime);
            int intDays = ts.Days;
            int intHours = ts.Hours;
            int intMinutes = ts.Minutes;
            int intSeconds = ts.Seconds;

            if (intDays > 0)
                return string.Format("{0} days ago", intDays);

            if (intHours > 0)
                return string.Format("{0} hours ago", intHours);

            if (intMinutes > 0)
                return string.Format("{0} minutes ago", intMinutes);

            if (intSeconds > 0)
                return string.Format("{0} seconds ago", intSeconds);

            // let's handle future times..just in case
            if (intDays < 0)
                return string.Format("in {0} days ago", Math.Abs(intDays));

            if (intHours < 0)
                return string.Format("in {0} hours ago", Math.Abs(intHours));

            if (intMinutes < 0)
                return string.Format("in {0} minutes ago", Math.Abs(intMinutes));

            if (intSeconds < 0)
                return string.Format("in {0} seconds ago", Math.Abs(intSeconds));

            return "a bit";
        }
    }
}
