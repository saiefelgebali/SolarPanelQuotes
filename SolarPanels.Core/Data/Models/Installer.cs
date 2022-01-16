using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core.Data.JSON;

namespace SolarPanels.Core.Data.Models
{
    public class Installer
    {
        public readonly string Id;
        public readonly double CallOutCost;
        public readonly double CostPerPanel;

        public Installer() { }

        public Installer(JSONInstaller jsonInstaller)
        {
            Id = jsonInstaller.Id;
            CallOutCost = jsonInstaller.CallOutCost;
            CostPerPanel = jsonInstaller.CostPerPanel;
        }
    }
}
