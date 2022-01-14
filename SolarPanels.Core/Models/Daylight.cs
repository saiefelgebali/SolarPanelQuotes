using SolarPanels.Core.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Models
{
    public class Daylight
    {
        public readonly int Month;
        public readonly double HoursOfDaylightPerDay;

        public Daylight(JSONDaylight jsonDaylight)
        {
            Month = jsonDaylight.Month;
            HoursOfDaylightPerDay = jsonDaylight.HoursOfDaylightPerDay;
        }
    }
}
