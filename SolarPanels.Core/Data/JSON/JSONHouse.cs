using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Data.JSON
{
    public class JSONHouse : BaseJSONData
    {
        public string Id { get; set; }
        public string RoofSize { get; set; }
        public double DaylightElectricityConsumption { get; set; }
        public double ElectricityCost { get; set; }
    }
}
