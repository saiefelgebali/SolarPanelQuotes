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
