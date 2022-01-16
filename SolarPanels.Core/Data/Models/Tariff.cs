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
        public readonly string Name;
        public readonly double Price;
        public readonly double ExpiredPrice;
        public readonly double MinimumFeedAmount;
        public readonly double MaximumFeedAmount;
        public readonly DateTime Expiry;

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
