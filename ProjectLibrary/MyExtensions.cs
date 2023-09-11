using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public static class MyExtensions
    {
        public static bool IsBusinessDay(this DateTime dt)
        {
            return dt.DayOfWeek != DayOfWeek.Saturday &&
                dt.DayOfWeek != DayOfWeek.Sunday;

        }
    }
}
