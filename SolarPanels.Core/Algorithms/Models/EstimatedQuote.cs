using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Algorithms.Models
{
    public class EstimatedQuote
    {
        public FittedPanels Panels { get; private set; }
        public FittedInstaller Installer { get; private set; }
        public FittedTariff Tariff { get; private set; }

        public double TotalPrice { get; private set; }

        public double[] AverageProfits { get; private set; }

        public double AverageDailyProfit { get; private set; }

        public double DaysToBreakEven { get; private set; }

        public EstimatedQuote(FittedPanels panels, FittedInstaller installer, FittedTariff tariff, double electricityCost)
        {
            Panels = panels;
            Installer = installer;
            Tariff = tariff;

            // Calculate total quote price
            TotalPrice = Panels.TotalCost + Installer.TotalPrice;

            // Calculate average profits over each month
            var averageCost = Tariff.AverageConsumption * electricityCost;
            AverageProfits = tariff.AverageRevenues.Select(revenue => revenue - averageCost).ToArray();

            // Calculate time to break even
            AverageDailyProfit = AverageProfits.Average();
            if (AverageDailyProfit > 0) DaysToBreakEven = TotalPrice / AverageDailyProfit;
            else if (AverageDailyProfit <= 0) DaysToBreakEven = double.PositiveInfinity;
        }
    }
}
