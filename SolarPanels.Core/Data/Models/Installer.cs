using SolarPanels.Core.Data.JSON;

namespace SolarPanels.Core.Data.Models
{
    public class Installer
    {
        public string Id { get; private set; }
        public double CallOutCost { get; private set; }
        public double CostPerPanel { get; private set; }

        public Installer() { }

        public Installer(JSONInstaller jsonInstaller)
        {
            Id = jsonInstaller.Id;
            CallOutCost = jsonInstaller.CallOutCost;
            CostPerPanel = jsonInstaller.CostPerPanel;
        }
    }
}
