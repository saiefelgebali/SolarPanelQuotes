using SolarPanels.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
