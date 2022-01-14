using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core.JSON;

namespace SolarPanels.Core.Models
{
    public class Installer
    {
        public readonly string Id;
        public readonly double CallOutCost;
        public readonly double CostPerPanel;

        public Installer(JSONInstaller jsonInstaller)
        {
            Id = jsonInstaller.Id;
            CallOutCost = jsonInstaller.CallOutCost;
            CostPerPanel = jsonInstaller.CostPerPanel;
        }
    }
}
