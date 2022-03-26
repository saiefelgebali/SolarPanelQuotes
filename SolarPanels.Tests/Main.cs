using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.Json;
using SolarPanels.Core;
using SolarPanels.Core.Algorithms;
using System.Collections.Generic;
using SolarPanels.Core.Algorithms.Models;

namespace SolarPanels.Tests
{
    [TestClass]
    public class Main
    {
        PanelFitter panelFitter = new PanelFitter();
        InstallerFitter installerFitter = new InstallerFitter();
        TariffFitter tariffFitter = new TariffFitter();

        [TestMethod]
        public void GetEstimatedQuotes()
        {
            var roofSize = (5, 4);
            var averageConsumption = 9;
            var electricityCost = 0.073;
            var budget = 5500;

            var quotes = QuoteEstimator.GetQuotes(new HouseSpecifications
            {
                RoofSize = roofSize,
                AverageConsumption = averageConsumption,
                ElectricityCost = electricityCost,
                Budget = budget
            });

            Assert.IsNotNull(quotes);
        }
        
        [TestMethod]
        public void GetEstimatedQuotesOutOfBudget()
        {
            var roofSize = (5, 4);
            var averageConsumption = 9;
            var electricityCost = 0.073;
            var budget = 1000;

            var (quotes, quotesOOB) = QuoteEstimator.GetQuotesWithOutOfBudget(new HouseSpecifications
            {
                RoofSize = roofSize,
                AverageConsumption = averageConsumption,
                ElectricityCost = electricityCost,
                Budget = budget
            });

            Assert.IsNotNull(quotes);
            Assert.IsNotNull(quotesOOB);
        }
    }
}
