using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarPanels.Core.Algorithms;
using SolarPanels.Core.Algorithms.Models;

namespace SolarPanels.Tests
{
    [TestClass]
    public class Main
    {
        [TestMethod]
        public void GetEstimatedQuotes()
        {
            var roofSize = (5, 4);
            var averageConsumption = 9;
            var electricityCost = 0.073;
            var budget = 5500;

            var quotes = QuoteEstimator.GetQuotes(new HouseSpecifications
            {
                RoofLength = roofSize.Item1,
                RoofWidth = roofSize.Item2,
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
                RoofLength = roofSize.Item1,
                RoofWidth = roofSize.Item2,
                AverageConsumption = averageConsumption,
                ElectricityCost = electricityCost,
                Budget = budget
            });

            Assert.IsNotNull(quotes);
            Assert.IsNotNull(quotesOOB);
        }
    }
}
