using SolarPanels.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Algorithms.Models
{
    public class FittedPanel
    {
        public readonly Panel Panel;
        public readonly int Count;
        public readonly double TotalCost;
        public readonly double TotalPower;
        public readonly double TotalEfficiency;
        public readonly double TotalUsefulPower;

        public FittedPanel(Panel panel, int count)
        {
            Panel = panel;
            Count = count;
            TotalCost = panel.Cost * Count;
            TotalPower = panel.Power * Count;
            TotalEfficiency = panel.Efficiency * Count;
            TotalUsefulPower = panel.UsefulPower * Count;
        }
    }
}
