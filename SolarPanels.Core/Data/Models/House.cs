using SolarPanels.Core.Data.JSON;
using System;

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
