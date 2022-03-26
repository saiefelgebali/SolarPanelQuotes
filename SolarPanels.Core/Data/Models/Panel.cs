using SolarPanels.Core.Data.JSON;
using System;

namespace SolarPanels.Core.Data.Models
{
    public class Panel
    {
        public string Manufacturer;
        public string Model { get; private set; }
        public string Url { get; private set; }
        public double Power { get; private set; }
        public double Efficiency { get; private set; }
        public double Weight { get; private set; }
        public double Cost { get; private set; }
        public double UsefulPower { get; private set; }
        public (double Length, double Width) Size { get; private set; }

        public Panel() { }

        public Panel(JSONPanel jsonPanel)
        {
            Manufacturer = jsonPanel.Manufacturer;
            Model = jsonPanel.Model;
            Url = jsonPanel.Url;

            Power = Convert.ToDouble(jsonPanel.Power);
            Efficiency = Convert.ToDouble(jsonPanel.Efficiency) / 100;
            Weight = Convert.ToDouble(jsonPanel.Weight);
            Cost = Convert.ToDouble(jsonPanel.Cost);

            // Calculate the useful power based on efficiency
            UsefulPower = Power * Efficiency;

            // Convert 'Size' tuple to 'Length' and 'Width' properties
            var size = jsonPanel.Size.Split(',');
            var length = Convert.ToDouble(size[0]);
            var width = Convert.ToDouble(size[1]);
            Size = (length, width);
        }
    }
}
