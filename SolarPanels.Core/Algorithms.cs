using SolarPanels.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core
{
    public static class Algorithms
    {
        public static Dictionary<Panel, (int Count, double TotalCost)> FitPanelsToRoof(Panel[] panelsData, (double Length, double Width) roofSize)
        {
            var panelsCount = new Dictionary<Panel, (int, double)>();

            foreach (var panel in panelsData)
            {
                var lengthCount = roofSize.Length / panel.Size.Length;
                var widthCount = roofSize.Width / panel.Size.Width;
                var count = Convert.ToInt32(
                    Math.Floor(lengthCount) * Math.Floor(widthCount)
                    );
                var totalCost = panel.Cost * count;
                panelsCount[panel] = (count, totalCost);
            }

            return panelsCount;
        }

        public static KeyValuePair<Panel, (int Count, double TotalCost)>[] MostAffordablePanels(Panel[] panelsData, (double Length, double Width) roofSize)
        {
            var fittedPanels = FitPanelsToRoof(panelsData, roofSize);
            return fittedPanels.ToArray().OrderBy(x => x.Value.TotalCost).ToArray();
        }
    }
}
