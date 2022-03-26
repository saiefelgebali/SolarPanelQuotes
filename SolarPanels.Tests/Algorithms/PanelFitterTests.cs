using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarPanels.Core.Algorithms;
using SolarPanels.Core.Data.Models;

namespace SolarPanels.Algorithms.Tests
{
    [TestClass]
    public class PanelFitterTests
    {
        [TestMethod]
        public void FitPanelsToRoof()
        {
            var panelFitter = new PanelFitter();
            var fittings = panelFitter.FitPanels((5, 4));

            // Test each fitting
            foreach (var fitting in fittings)
            {
                Assert.IsInstanceOfType(fitting.Panel, typeof(Panel));
                Assert.IsInstanceOfType(fitting.Count, typeof(int));
                Assert.IsInstanceOfType(fitting.TotalCost, typeof(double));
                Assert.IsInstanceOfType(fitting.TotalPower, typeof(double));
                Assert.IsInstanceOfType(fitting.TotalUsefulPower, typeof(double));
                Assert.IsInstanceOfType(fitting.AverageOutputs, typeof(double[]));

                // Ensure AverageOutputs have 12 values for each month of the year
                Assert.AreEqual(fitting.AverageOutputs.Length, 12);

                switch (fitting.Panel.Manufacturer)
                {
                    case "Solaria":
                        Assert.AreEqual(fitting.Count, 9);
                        break;

                    case "Solar Power Supply":
                        Assert.AreEqual(fitting.Count, 28);
                        break;

                    case "Trina":
                        Assert.AreEqual(fitting.Count, 8);
                        break;

                    case "Viridian":
                        Assert.AreEqual(fitting.Count, 12);
                        break;

                    case "Q Cells":
                        Assert.AreEqual(fitting.Count, 8);
                        break;

                    case "LG":
                        Assert.AreEqual(fitting.Count, 8);
                        break;

                    default:
                        break;
                }
            }


        }

        //[TestMethod]
        //public void FitPanelsByCost()
        //{
        //    panelFitter.FitPanels(Panels, roofSize: (5,4));
        //    var fittings = panelFitter.SortByCost();

        //    Assert.AreEqual(fittings.Length, Panels.Length);

        //    double min = double.PositiveInfinity;
        //    foreach (var fitting in fittings)
        //    {
        //        var curr = fitting.TotalCost;
        //        if (curr < min) min = curr;
        //    }
        //    Assert.AreEqual(min, fittings[0].TotalCost);
        //}

        //[TestMethod]
        //public void FitPanelsWithBudget()
        //{
        //    var panelFitter = new PanelFitter(Daylights, roofSize: (5, 4), budget: 1000);
        //    panelFitter.FitPanels(Panels, 0);
        //    var fittings = panelFitter.GetFittedPanels();

        //    Assert.IsTrue(fittings.Length < Panels.Length);
        //}
    }
}
