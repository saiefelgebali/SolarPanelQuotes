using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarPanels.Core.Algorithms;
using SolarPanels.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Tests
{
    [TestClass]
    public class InstallerFitterTests
    {
        static readonly Installer[] Installers = TestUtility.InstallerDataset.Data;

        [TestMethod]
        public void FitInstallers()
        {
            var installerFitter = new InstallerFitter();
            var panelCounts = new int[] { 0, 15, 100, -6 };

            var expectedPrices = new double[,]
            {
                { 1500, 3000, 11500, -1 }, // JNS Solar
                { 6000, 6375, 8500, -1 }, // Solar Energy Solutions Norfolk
                { 2000, 2975, 8500, -1 } // Cambridge Solar
            };

            for (int i = 0; i < panelCounts.Length; i++)
            {
                var fittings = installerFitter.FitInstallers(Installers, panelCounts[i]);

                if (panelCounts[i] < 0)
                {
                    Assert.IsNull(fittings);
                    continue;
                }


                foreach (var fitting in fittings)
                {
                    switch (fitting.Installer.Id)
                    {
                        case "JNS Solar":
                            Assert.AreEqual(fitting.TotalPrice, expectedPrices[0, i]);
                            break;
                        case "Solar Energy Solutions Norfolk":
                            Assert.AreEqual(fitting.TotalPrice, expectedPrices[1, i]);
                            break;
                        case "Cambridge Solar":
                            Assert.AreEqual(fitting.TotalPrice, expectedPrices[2, i]);
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }
}
