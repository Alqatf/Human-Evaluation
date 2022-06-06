using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH_Project.Models.Helper
{
    public class DateTimeHelper
    {
        public static DateTime GetDate()
        {
            DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
            DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
            return localTime;
        }
    }
}
