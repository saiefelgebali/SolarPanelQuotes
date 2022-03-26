namespace SolarPanels.Core.Algorithms.Models
{
    public class HouseSpecifications
    {
        public (double, double) RoofSize { get; set; }
        public double AverageConsumption { get; set; }
        public double ElectricityCost { get; set; }
        public double Budget { get; set; }
    }
}
