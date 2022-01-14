using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.JSON
{
    public class JSONHouse
    {
        public string Id { get; set; }
        public string RoofSize { get; set; }
        public double DaylightElectricityConsumption { get; set; }
        public double ElectricityCost { get; set; }
    }
}
