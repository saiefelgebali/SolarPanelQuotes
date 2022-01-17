using SolarPanels.Core.Algorithms.Models;
using SolarPanels.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Algorithms
{
    public class PanelFitter
    {
        private FittedPanel[] FittedPanels;

        private (double Length, double Width) RoofSize = (0, 0);

        private double Budget = double.PositiveInfinity;

        public PanelFitter((double, double)? roofSize = null, double? budget = null)
        {
            if (budget != null) Budget = (double)budget;
            if (roofSize != null) RoofSize = ((double, double))roofSize;
        }

        public void SetRoofSize(double length, double width) => RoofSize = (length, width);
        public void SetBudget(double budget) => Budget = budget;

        public void FitPanels(Panel[] panels)
        {
            FittedPanels = new FittedPanel[panels.Length];

            for (int i = 0; i < panels.Length; i++)
            {
                var panel = panels[i];
                var lengthCount = RoofSize.Length / panel.Size.Length;
                var widthCount = RoofSize.Width / panel.Size.Width;
                var count = Convert.ToInt32(
                    Math.Floor(lengthCount) * Math.Floor(widthCount)
                    );
                FittedPanels[i] = new FittedPanel(panel, count);
            }
        }

        public FittedPanel[] GetFittedPanels() =>
            FittedPanels
            .Where(p => p.TotalCost < Budget)
            .ToArray();

        public FittedPanel[] SortByCost() =>
            GetFittedPanels()
            .OrderBy(p => p.TotalCost)
            .ToArray();

        public FittedPanel[] SortByPower() => 
            GetFittedPanels()
            .OrderBy(p => p.TotalPower)
            .ToArray();        
        
        public FittedPanel[] SortByUsefulPower() => 
            GetFittedPanels()
            .OrderBy(p => p.TotalUsefulPower)
            .ToArray();
    }
}
