using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SolarPanels.Core;
using System.IO;

namespace SolarPanels.Tests
{
    [TestClass]
    public class DatasetTests
    {
        [TestMethod]
        public void ParseDaylights()
        {
            var daylights = TestUtility.DaylightDataset;

            Assert.IsNotNull(daylights);
            Assert.IsNotNull(daylights.Data);
            Assert.IsTrue(daylights.Data.Length > 0);

            var sample = daylights.Data[0];

            Assert.IsInstanceOfType(sample.Month, typeof(int));
            Assert.IsInstanceOfType(sample.HoursOfDaylightPerDay, typeof(double));
        }
        
        [TestMethod]
        public void ParseHouses()
        {
            var houses = TestUtility.HouseDataset;

            Assert.IsNotNull(houses);
            Assert.IsNotNull(houses.Data);
            Assert.IsTrue(houses.Data.Length > 0);

            var sample = houses.Data[0];

            Assert.IsInstanceOfType(sample.Id, typeof(string));
            Assert.IsInstanceOfType(sample.DaylightElectricityConsumption, typeof(double));
            Assert.IsInstanceOfType(sample.ElectricityCost, typeof(double));
            Assert.IsInstanceOfType(sample.RoofSize, typeof((double, double)));
        }
        
        [TestMethod]
        public void ParseInstallers()
        {
            var installers = TestUtility.InstallerDataset;

            Assert.IsNotNull(installers);
            Assert.IsNotNull(installers.Data);
            Assert.IsTrue(installers.Data.Length > 0);

            var sample = installers.Data[0];

            Assert.IsInstanceOfType(sample.Id, typeof(string));
            Assert.IsInstanceOfType(sample.CallOutCost, typeof(double));
            Assert.IsInstanceOfType(sample.CostPerPanel, typeof(double));
        }

        [TestMethod]
        public void ParsePanels()
        {
            var panels = TestUtility.PanelDataset;

            Assert.IsNotNull(panels);
            Assert.IsNotNull(panels.Data);
            Assert.IsTrue(panels.Data.Length > 0);

            var sample = panels.Data[0];

            Assert.IsInstanceOfType(sample.Manufacturer, typeof(string));
            Assert.IsInstanceOfType(sample.Model, typeof(string));
            Assert.IsInstanceOfType(sample.Url, typeof(string));
            Assert.IsInstanceOfType(sample.Power, typeof(double));
            Assert.IsInstanceOfType(sample.Efficiency, typeof(double));
            Assert.IsInstanceOfType(sample.Weight, typeof(double));
            Assert.IsInstanceOfType(sample.Cost, typeof(double));
            Assert.IsInstanceOfType(sample.UsefulPower, typeof(double));
            Assert.IsInstanceOfType(sample.Size, typeof((double, double)));

            Assert.AreEqual(sample.UsefulPower, sample.Power * sample.Efficiency);
        }
        
        [TestMethod]
        public void ParseTariffs()
        {
            var tariffs = TestUtility.TariffDataset;

            Assert.IsNotNull(tariffs);
            Assert.IsNotNull(tariffs.Data);
            Assert.IsTrue(tariffs.Data.Length > 0);

            var sample = tariffs.Data[0];

            Assert.IsInstanceOfType(sample.Name, typeof(string));
            Assert.IsInstanceOfType(sample.Price, typeof(double));
            Assert.IsInstanceOfType(sample.ExpiredPrice, typeof(double));
            Assert.IsInstanceOfType(sample.MinimumFeedAmount, typeof(double));
            Assert.IsInstanceOfType(sample.MaximumFeedAmount, typeof(double?));
            Assert.IsInstanceOfType(sample.Expiry, typeof(DateTime));
        }
    }
}
