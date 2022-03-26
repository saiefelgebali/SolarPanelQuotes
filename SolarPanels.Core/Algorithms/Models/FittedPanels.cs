using SolarPanels.Core.Data.Models;

namespace SolarPanels.Core.Algorithms.Models
{
    public class FittedPanels
    {
        public Panel Panel { get; private set; }
        public int Count { get; set; }
        public double TotalCost { get; private set; }
        public double TotalPower { get; private set; }
        public double TotalUsefulPower { get; private set; }

        // The average output of the set of panels in kWh
        // for every month of the year.
        public double[] AverageOutputs { get; private set; }

        public FittedPanels(Panel panel, int count)
        {
            Panel = panel;
            Count = count;
            TotalCost = panel.Cost * Count;
            TotalPower = panel.Power * Count;
            TotalUsefulPower = panel.UsefulPower * Count;

            // Average outputs is an array of size 12 for each month in the year
            AverageOutputs = new double[12];

            foreach (var month in DaylightDataset.Data)
            {
                // calculate total output for each month in kWh
                var totalOutput = (TotalUsefulPower / 1000) * month.HoursOfDaylightPerDay;
                AverageOutputs[month.Month - 1] = totalOutput;
            }
        }
    }
}
