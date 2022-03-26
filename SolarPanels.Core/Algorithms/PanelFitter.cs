using SolarPanels.Core.Algorithms.Models;
using SolarPanels.Core.Data.Models;
using System;

namespace SolarPanels.Core.Algorithms
{
    public class PanelFitter
    {
        private readonly Panel[] Panels;

        public PanelFitter()
        {
            Panels = PanelDataset.Data;
        }

        public FittedPanels[] FitPanels((double length, double width) roofSize)
        {
            var fittedPanels = new FittedPanels[Panels.Length];

            for (int i = 0; i < Panels.Length; i++)
            {
                // Fit panels in normal orientation
                var panel = Panels[i];
                var lengthCountNormal = roofSize.length / panel.Length;
                var widthCountNormal = roofSize.width / panel.Width;
                var countNormal = Convert.ToInt32(
                    Math.Floor(lengthCountNormal) * Math.Floor(widthCountNormal)
                    );

                // Fit panels in rotated orientation
                var lengthCountRotated = roofSize.length / panel.Width;
                var widthCountRotated = roofSize.width / panel.Length;
                var countRotated = Convert.ToInt32(
                    Math.Floor(lengthCountRotated) * Math.Floor(widthCountRotated)
                    );

                // Use greater count
                var count = Math.Max(countNormal, countRotated);
                fittedPanels[i] = new FittedPanels(panel, count);
            }

            return fittedPanels;
        }
    }
}
