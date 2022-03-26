namespace SolarPanels.Core.Data.JSON
{
    public class JSONTariff : BaseJSONData
    {
        public string Name { get; set; }
        public string Expiry { get; set; }
        public double Price { get; set; }
        public double ExpiredPrice { get; set; }
        public double MinimumFeedAmount { get; set; }
        public double? MaximumFeedAmount { get; set; }
    }
}
