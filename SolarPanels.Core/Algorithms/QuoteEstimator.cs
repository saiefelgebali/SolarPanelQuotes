using SolarPanels.Core.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Algorithms
{
    public static class QuoteEstimator
    {
        private static readonly PanelFitter PanelFitter = new ();
        private static readonly InstallerFitter InstallerFitter = new ();
        private static readonly TariffFitter TariffFitter = new ();

        /// <summary>
        /// Handle every possible combination of quotes with the house specifications.
        /// </summary>
        /// <param name="specs"></param>
        /// <param name="handleQuote">Function that would handle each quote</param>
        private static void GetQuotes(HouseSpecifications specs,Action<EstimatedQuote> handleQuote)
        {
            // Fit panels
            var fittedPanels = PanelFitter.FitPanels(specs.RoofSize);

            foreach (var fittedPanel in fittedPanels)
            {
                var fittedInstallers = InstallerFitter.FitInstallers(fittedPanel.Count);
                var fittedTariffs = TariffFitter.FitTariffs(fittedPanel, specs.AverageConsumption);

                // always use the cheapest installer
                var fittedInstaller = fittedInstallers.OrderBy(installer => installer.TotalPrice).First();

                foreach (var fittedTariff in fittedTariffs)
                {
                    var quote = new EstimatedQuote(fittedPanel, fittedInstaller, fittedTariff, specs.ElectricityCost);

                    // allow quote to be handled in different ways
                    handleQuote(quote);
                }
            }
        }

        public static EstimatedQuote[] GetQuotes(HouseSpecifications specs)
        {
            var quotes = new List<EstimatedQuote>();

            // Add quote if it falls within the budget
            GetQuotes(specs, (quote) => {
                if (quote.TotalPrice <= specs.Budget) quotes.Add(quote);
            });

            return quotes.ToArray();
        }

        // Get quotes with the quotesOutOfBudget seperated in a different array
        public static (EstimatedQuote[] quotes, EstimatedQuote[] quotesOutOfBudget) GetQuotesWithOutOfBudget(HouseSpecifications specs)
        {
            var quotes = new List<EstimatedQuote>();
            var quotesOutOfBudget = new List<EstimatedQuote>();

            GetQuotes(specs, (quote) =>
            {
                if (quote.TotalPrice <= specs.Budget) quotes.Add(quote);
                else if (quote.TotalPrice > specs.Budget) quotesOutOfBudget.Add(quote);
            });

            return (quotes.ToArray(), quotesOutOfBudget.ToArray());
        }
    }
}
