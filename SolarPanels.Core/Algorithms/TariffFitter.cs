using SolarPanels.Core.Algorithms.Models;
using SolarPanels.Core.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SolarPanels.Core.Algorithms
{
    public class TariffFitter
    {
        private readonly Tariff[] Tariffs;

        public TariffFitter()
        {
            Tariffs = TariffDataset.Data;
        }

        /// <param name="averageConsumption">Average Daylight Consumption of a household in Kilowatt-Hours (kWh)</param>
        public FittedTariff[] FitTariffs(FittedPanels fitting, double averageConsumption)
        {
            var tarifFittings = new List<FittedTariff>();

            foreach (var tariff in Tariffs)
            {
                var tariffFitting = new FittedTariff(fitting, tariff, averageConsumption);

                if (tariffFitting.AverageFeedAmounts.Min() >= tariff.MinimumFeedAmount)
                {
                    tarifFittings.Add(new FittedTariff(fitting, tariff, averageConsumption));
                }
            }

            return tarifFittings.ToArray();
        }
    }
}
