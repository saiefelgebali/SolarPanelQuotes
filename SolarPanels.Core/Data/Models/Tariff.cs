using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core.Data.JSON;

namespace SolarPanels.Core.Data.Models
{
    public class Tariff
    {
        public string Name { get; private set; }
        public double Price  { get; private set; }
        public double ExpiredPrice  { get; private set; }
        public double MinimumFeedAmount  { get; private set; }
        public double MaximumFeedAmount  { get; private set; }
        public DateTime Expiry  { get; private set; }

        public Tariff() { }

        public Tariff(JSONTariff jsonTariffs)
        {
            Name = jsonTariffs.Name;
            Price = jsonTariffs.Price;
            ExpiredPrice = jsonTariffs.ExpiredPrice;
            MinimumFeedAmount = jsonTariffs.MinimumFeedAmount;

            if (jsonTariffs.MaximumFeedAmount != null)
            {
                MaximumFeedAmount = (double)jsonTariffs.MaximumFeedAmount;
            }
            else
            {
                MaximumFeedAmount = double.PositiveInfinity;
            }

            Expiry = DateTime.Parse(jsonTariffs.Expiry);
        }
    }
}
