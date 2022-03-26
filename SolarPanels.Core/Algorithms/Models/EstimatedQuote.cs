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

        public double AverageProfits { get; private set; }

        public EstimatedQuote(FittedPanels panels, FittedInstaller installer, FittedTariff tariff)
        {
            Panels = panels;
            Installer = installer;
            Tariff = tariff;

            // Calculate total quote price
            TotalPrice = Panels.TotalCost + Installer.TotalPrice;
        }
    }
}
