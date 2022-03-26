using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarPanels.Core;
using System;

namespace SolarPanels.Tests
{
    [TestClass]
    public class DatasetTests
    {
        [TestMethod]
        public void ParseDaylights()
        {
            Assert.IsNotNull(DaylightDataset.Data);
            Assert.IsTrue(DaylightDataset.Data.Length > 0);

            var sample = DaylightDataset.Data[0];

            Assert.IsInstanceOfType(sample.Month, typeof(int));
            Assert.IsInstanceOfType(sample.HoursOfDaylightPerDay, typeof(double));
        }
        
        [TestMethod]
        public void ParseHouses()
        {
            Assert.IsNotNull(HouseDataset.Data);
            Assert.IsTrue(HouseDataset.Data.Length > 0);

            var sample = HouseDataset.Data[0];

            Assert.IsInstanceOfType(sample.Id, typeof(string));
            Assert.IsInstanceOfType(sample.DaylightElectricityConsumption, typeof(double));
            Assert.IsInstanceOfType(sample.ElectricityCost, typeof(double));
            Assert.IsInstanceOfType(sample.RoofSize, typeof((double, double)));
        }
        
        [TestMethod]
        public void ParseInstallers()
        {
            Assert.IsNotNull(InstallerDataset.Data);
            Assert.IsTrue(InstallerDataset.Data.Length > 0);

            var sample = InstallerDataset.Data[0];

            Assert.IsInstanceOfType(sample.Id, typeof(string));
            Assert.IsInstanceOfType(sample.CallOutCost, typeof(double));
            Assert.IsInstanceOfType(sample.CostPerPanel, typeof(double));
        }

        [TestMethod]
        public void ParsePanels()
        {
            Assert.IsNotNull(PanelDataset.Data);
            Assert.IsTrue(PanelDataset.Data.Length > 0);

            var sample = PanelDataset.Data[0];

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
            Assert.IsNotNull(TariffDataset.Data);
            Assert.IsTrue(TariffDataset.Data.Length > 0);

            var sample = TariffDataset.Data[0];

            Assert.IsInstanceOfType(sample.Name, typeof(string));
            Assert.IsInstanceOfType(sample.Price, typeof(double));
            Assert.IsInstanceOfType(sample.ExpiredPrice, typeof(double));
            Assert.IsInstanceOfType(sample.MinimumFeedAmount, typeof(double));
            Assert.IsInstanceOfType(sample.MaximumFeedAmount, typeof(double?));
            Assert.IsInstanceOfType(sample.Expiry, typeof(DateTime));
        }
    }
}
