using SolarPanels.Core.Data.Models;

namespace SolarPanels.Core.Algorithms.Models
{
    public class FittedInstaller
    {
        public Installer Installer { get; private set; }
        public double TotalPrice { get; private set; }

        public FittedInstaller(Installer installer, double totalPrice)
        {
            Installer = installer;
            TotalPrice = totalPrice;
        }
    }
}
