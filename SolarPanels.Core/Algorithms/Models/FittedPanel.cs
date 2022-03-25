using SolarPanels.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Algorithms.Models
{
    public class FittedPanel
    {
        public Panel Panel { get; private set; }
        public int Count { get; set; }
        public double TotalCost { get; private set; }
        public double TotalPower { get; private set; }
        public double TotalEfficiency { get; private set; }
        public double TotalUsefulPower { get; private set; }
        public double AverageDailyOutput { get; private set; }

        public FittedPanelTariff[] FittedPanelTariffs { get; private set; }
        private readonly double AverageDaylightConsumption;

        public FittedPanel(Panel panel, int count, double averageDaylight, double averageDaylightConsumption)
        {
            Panel = panel;
            Count = count;
            TotalCost = panel.Cost * Count;
            TotalPower = panel.Power * Count;
            TotalEfficiency = panel.Efficiency * Count;
            TotalUsefulPower = panel.UsefulPower * Count;

            // Average output in kWh
            AverageDailyOutput = (TotalUsefulPower / 1000) * averageDaylight;
            AverageDaylightConsumption = averageDaylightConsumption;
        }

        public void FitTariffs(Tariff[] tariffs)
        {
            var fittedPanelTariffs = new List<FittedPanelTariff>();

            foreach (var tariff in tariffs)
            {
                var feedAmount = AverageDailyOutput - AverageDaylightConsumption;
                if (feedAmount > tariff.MinimumFeedAmount && feedAmount < tariff.MaximumFeedAmount)
                {
                    var fittedTariff = new FittedPanelTariff(this, tariff, AverageDaylightConsumption);
                    fittedPanelTariffs.Add(fittedTariff);
                }
            }

            FittedPanelTariffs = fittedPanelTariffs.ToArray();
        }
    }
}
