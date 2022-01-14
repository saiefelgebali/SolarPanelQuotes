using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core.Data;

namespace SolarPanels.Tests
{
    [TestClass]
    public class DataTests
    {
        [TestMethod]
        public void ParsePanels()
        {
            var panelsPath = @"D:/datasets/SolarPanels/Panels.json";
            var panels = new Panels(panelsPath);

            Assert.IsNotNull(panels);
            Assert.IsNotNull(panels.Data);
            Assert.IsTrue(panels.Data.Length > 0);

            var sample = panels.Data[0];

            Assert.IsInstanceOfType(sample.Manufacturer, typeof(string));
            Assert.IsInstanceOfType(sample.Model, typeof(string));
            Assert.IsInstanceOfType(sample.Url, typeof(string));
            Assert.IsInstanceOfType(sample.Length, typeof(double));
            Assert.IsInstanceOfType(sample.Length, typeof(double));
            Assert.IsInstanceOfType(sample.Power, typeof(double));
            Assert.IsInstanceOfType(sample.Efficiency, typeof(double));
            Assert.IsInstanceOfType(sample.Weight, typeof(double));
            Assert.IsInstanceOfType(sample.Cost, typeof(double));
        }
    }
}
