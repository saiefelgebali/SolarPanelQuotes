using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core.Data.JSON;

namespace SolarPanels.Core.Data.Models
{
    public class House
    {
        public readonly string Id;
        public readonly double DaylightElectricityConsumption;
        public readonly double ElectricityCost;
        public readonly (double, double) RoofSize;

        public House() { }

        public House(JSONHouse jsonHouse)
        {
            Id = jsonHouse.Id;
            DaylightElectricityConsumption = jsonHouse.DaylightElectricityConsumption;
            ElectricityCost = jsonHouse.ElectricityCost;

            var roofSize = jsonHouse.RoofSize.Split(',');
            var length = Convert.ToDouble(roofSize[0]);
            var width = Convert.ToDouble(roofSize[1]);
            RoofSize = (length, width);
        }
    }
}
