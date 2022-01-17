using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core;
using SolarPanels.Core.Data.Models;
using SolarPanels.Core.Algorithms;

namespace SolarPanels.Tests
{
    [TestClass]
    public class PanelFitterTests
    {
        static readonly Panel[] Panels = TestUtility.PanelDataset.Data;

        [TestMethod]
        public void FitPanelsToRoof()
        {
            var panelFitter = new PanelFitter();
            panelFitter.SetRoofSize(5, 4);
            panelFitter.FitPanels(Panels);
            var fittings = panelFitter.GetFittedPanels();

            Assert.AreEqual(fittings.Length, Panels.Length);
            foreach (var fitting in fittings)
            {
                Assert.IsInstanceOfType(fitting.Panel, typeof(Panel));
                Assert.IsInstanceOfType(fitting.Count, typeof(int));
                Assert.IsInstanceOfType(fitting.TotalCost, typeof(double));
                Assert.IsInstanceOfType(fitting.TotalPower, typeof(double));
                Assert.IsInstanceOfType(fitting.TotalEfficiency, typeof(double));
                Assert.IsInstanceOfType(fitting.TotalUsefulPower, typeof(double));
            }
        }

        [TestMethod]
        public void FitPanelsByCost()
        {
            var panelFitter = new PanelFitter();
            panelFitter.SetRoofSize(5, 4);
            panelFitter.FitPanels(Panels);
            var fittings = panelFitter.SortByCost();

            Assert.AreEqual(fittings.Length, Panels.Length);

            double min = double.PositiveInfinity;
            foreach (var fitting in fittings)
            {
                var curr = fitting.TotalCost;
                if (curr < min) min = curr;
            }
            Assert.AreEqual(min, fittings[0].TotalCost);
        }

        [TestMethod]
        public void FitPanelsWithBudget()
        {
            var panelFitter = new PanelFitter();
            panelFitter.SetRoofSize(5, 4);
            panelFitter.FitPanels(Panels);
            panelFitter.SetBudget(1000);
            var fittings = panelFitter.GetFittedPanels();

            Assert.IsTrue(fittings.Length < Panels.Length);
        }
    }
}
