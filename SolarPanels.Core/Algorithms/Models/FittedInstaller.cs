using SolarPanels.Core.Data.Models;

namespace SolarPanels.Core.Algorithms.Models
{
    public class FittedInstaller
    {
        public readonly Installer Installer;
        public readonly double TotalPrice;

        public FittedInstaller(Installer installer, double totalPrice)
        {
            Installer = installer;
            TotalPrice = totalPrice;
        }
    }
}
