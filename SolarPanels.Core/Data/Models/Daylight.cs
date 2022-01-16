using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core.Data.JSON;

namespace SolarPanels.Core.Data.Models
{
    public class Daylight
    {
        public int Month { get; private set; }
        public double HoursOfDaylightPerDay { get; private set; }

        public Daylight() { }

        public Daylight(JSONDaylight jsonDaylight)
        {
            Month = jsonDaylight.Month;
            HoursOfDaylightPerDay = jsonDaylight.HoursOfDaylightPerDay;
        }
    }
}
