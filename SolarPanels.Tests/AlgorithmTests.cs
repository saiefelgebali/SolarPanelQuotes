using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core;
using SolarPanels.Core.Data.Models;

namespace SolarPanels.Tests
{
    [TestClass]
    public class AlgorithmTests
    {
        static readonly Panel[] Panels = TestUtility.PanelDataset.Data;

        [TestMethod]
        public void FitPanelsToRoof()
        {

            var panelFittings = Algorithms.FitPanelsToRoof(Panels, (50, 10));

            Assert.AreEqual(panelFittings.Count, Panels.Length);
            foreach (var fitting in panelFittings)
            {
                Assert.IsInstanceOfType(fitting.Key, typeof(Panel));
                Assert.IsInstanceOfType(fitting.Value.Count, typeof(int));
                Assert.IsInstanceOfType(fitting.Value.TotalCost, typeof(double));
            }
        }

        [TestMethod]
        public void MostAffordablePanels()
        {
            var mostAffordablePanels = Algorithms.MostAffordablePanels(Panels, (50, 10));

            Assert.AreEqual(mostAffordablePanels.Length, Panels.Length);

            double min = double.PositiveInfinity;
            foreach (var result in mostAffordablePanels)
            {
                var curr = result.Value.TotalCost;
                if (curr < min) min = curr;
            }
            Assert.AreEqual(min, mostAffordablePanels[0].Value.TotalCost);
        }
    }
}
