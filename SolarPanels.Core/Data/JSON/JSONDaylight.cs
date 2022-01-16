using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Data.JSON
{
    public class JSONDaylight : BaseJSONData
    {
        public int Month { get; set; }
        public double HoursOfDaylightPerDay { get; set; }
    }
}
