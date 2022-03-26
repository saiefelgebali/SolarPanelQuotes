using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarPanels.Core.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Algorithms.Tests
{
    [TestClass]
    public class TariffFitterTests
    {
        [TestMethod]
        public void FitTariffs()
        {
            var tariffFitter = new TariffFitter();
            var panelFitter = new PanelFitter();

            var fittedPanels = panelFitter.FitPanels((5, 4));

            foreach (var fittedPanel in fittedPanels)
            {
                var fittedTariffs = tariffFitter.FitTariffs(fittedPanel, 5);

                Assert.IsNotNull(fittedTariffs);
                foreach (var fittedTariff in fittedTariffs)
                {
                    // ensure feed amounts are in correct tariff range
                    Assert.IsTrue(fittedTariff.AverageFeedAmounts.Min() >= fittedTariff.Tariff.MinimumFeedAmount);
                    Assert.IsTrue(fittedTariff.AverageFeedAmounts.Max() <= fittedTariff.Tariff.MaximumFeedAmount);
                }
            }
        }
    }
}
