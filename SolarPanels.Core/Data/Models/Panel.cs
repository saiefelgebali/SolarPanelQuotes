using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core.Data.JSON;

namespace SolarPanels.Core.Data.Models
{
    public class Panel
    {
        public readonly string Manufacturer;
        public readonly string Model;
        public readonly string Url;
        public readonly double Power;
        public readonly double Efficiency;
        public readonly double Weight;
        public readonly double Cost;
        public readonly double UsefulPower;
        public readonly (double Length, double Width) Size;

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
